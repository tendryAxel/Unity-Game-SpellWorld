using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointStats : AbstractModifiableStats
{
    [Header("Stats change")]
    [SerializeField]
    private List<Action> deathActions;

    public void TakeDamage(float manaDamage)
    {
        float damage = ManaDamageToHPDamage(manaDamage);
        if (damage < 0)
        {
            Debug.LogWarning("Damage must not be negative: " + damage);
            return;
        }

        var nextHealthPoints = GetValue - damage;
        if (nextHealthPoints < 0)
        {
            DeathEvent();
            return;
        }

        SetValue(nextHealthPoints);
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
