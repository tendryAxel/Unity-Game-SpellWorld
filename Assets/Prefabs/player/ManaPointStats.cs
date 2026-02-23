using System;
using System.Collections.Generic;
using UnityEngine;

public class ManaPointStats : MonoBehaviour
{
    [Header("Mana Points")]
    [SerializeField]
    private float maxManaPoints;
    public float GetMaxManaPoints => maxManaPoints;
    [SerializeField]
    private float manaPoints;
    public float GetManaPoints => manaPoints;
    [SerializeField]
    private float manaOutputRate;
    public float GetManaOutputRate => manaOutputRate;

    public void TakeMana(float requested)
    {
        if (manaPoints < requested)
        {
            Debug.LogWarning("Not Enough mana");
            return;
        }

        manaPoints -= requested;
    }
}
