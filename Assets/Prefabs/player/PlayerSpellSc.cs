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

    // TODO: remove SerializeField
    [SerializeField]
    private float handedMana = 0;

    public ShootData GetCurrentShootData()
    {
        return shoots[currentShootId];
    }

    public void CancelManaHolding()
    {
        handedMana = 0;
    }

    public void Shoot()
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
            handedMana += idlelyNeededToBeDelivered;

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

    public int GetSpellChargingPercent()
    {
        return (int) (handedMana / this.GetCurrentShootData().Mana * 100);
    }
}
