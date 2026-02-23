using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointStats : MonoBehaviour
{
    [Header("Health Points")]
    [SerializeField]
    private float maxHealthPoints;
    public float GetMaxHealthPoints => maxHealthPoints;
    [SerializeField]
    private float healthPoints;
    public float GetHealthPoints => healthPoints;

    [Header("Stats change")]
    [SerializeField]
    private List<Action> deathActions;
    [SerializeField]
    private List<Action> onChangeActions;

    public void TakeDamage(float manaDamage)
    {
        float damage = ManaDamageToHPDamage(manaDamage);
        if (damage < 0)
        {
            Debug.LogWarning("Damage must not be negative: " + damage);
            return;
        }

        var nextHealthPoints = healthPoints - damage;
        if (nextHealthPoints < 0)
        {
            DeathEvent();
            return;
        }

        healthPoints = nextHealthPoints;
    }

    float ManaDamageToHPDamage(float manaDamage)
    {
        return manaDamage * 1;
    }

    void DeathEvent()
    {
        foreach (Action action in this.deathActions)
        {
            action();
        }
    }

    public void RegisterDeathAction(Action action)
    {
        deathActions.Add(action);
    }
}
