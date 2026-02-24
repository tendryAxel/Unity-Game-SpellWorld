using System;
using System.Collections.Generic;
using UnityEngine;

public class ManaPointStats : AbstractModifiableStats
{
    [SerializeField]
    private float manaOutputRate;
    public float GetManaOutputRate => manaOutputRate;

    public void TakeMana(float requested)
    {
        if (GetValue < requested)
        {
            throw new NotEnoughManaException(GetValue, requested);
        }

        AddToValue(-requested);
    }
}

[System.Serializable]
public class NotEnoughManaException : System.Exception
{
    public NotEnoughManaException(float avalaible, float requested) : base("Not enough mana. Only: " + avalaible + " avalaible but: " + requested + " requested") { }
    public NotEnoughManaException(string message, System.Exception inner) : base(message, inner) {}
    protected NotEnoughManaException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}
