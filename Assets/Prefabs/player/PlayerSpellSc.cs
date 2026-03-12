using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellSc : MonoBehaviour
{
    [SerializeField]
    private List<ShootData> shoots;

    [SerializeField]
    private int currentShootId = 0;

    [SerializeField]
    private ManaPointStats manaPointStats;

    [SerializeField]
    private ShootManagementSc shootManagement;
    
    private float handedMana = 0;

    private List<Action<int>> onHandedManaPercentageChange = new();

    public ShootData GetCurrentShootData()
    {
        return shoots[currentShootId];
    }

    private void SetHandedMana(float value)
    {
        handedMana = value;
        foreach (Action<int> action in onHandedManaPercentageChange)
        {
            action(GetSpellChargingPercent());
        }
    }

    public void CancelManaHolding()
    {
        SetHandedMana(0);
    }

    public void LoadAndShoot()
    {
        ShootData toShoot = this.GetCurrentShootData();
        float neededMana = toShoot.Mana - handedMana;
        if (neededMana > 0)
        {
            float canBeAdded = manaPointStats.GetManaOutputRate * Time.deltaTime;
            float idlelyNeededToBeDelivered = Math.Min(neededMana, canBeAdded);
            if (idlelyNeededToBeDelivered > manaPointStats.GetValue)
            {
                CancelManaHolding();
                throw new NotEnoughManaException(manaPointStats.GetValue, idlelyNeededToBeDelivered);
            }
            SetHandedMana(handedMana + idlelyNeededToBeDelivered);

            return;
        }

        Vector3 source = transform.position;
        Vector3 target = transform.position + (transform.forward * 500);

        try
        {
            manaPointStats.TakeMana(handedMana);

            shootManagement.AddShoot(
                toShoot,
                source, target
            );
        }
        catch (NotEnoughManaException e)
        {
            Debug.LogWarning("Not Enough mana.\n" + e);
        }
        finally
        {
            CancelManaHolding();
        }
    }

    private int GetSpellChargingPercent()
    {
        return (int) (handedMana / this.GetCurrentShootData().Mana * 100);
    }
    
    public void RegisterOnHandedManaPercentageChange(Action<int> action)
    {
        onHandedManaPercentageChange.Add(action);
    }
}
