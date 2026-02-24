using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractModifiableStats : MonoBehaviour
{
    [Header("Stats Values")]
    [SerializeField]
    private float maxValue;
    public float GetMaxValue => maxValue;

    [SerializeField]
    private float value;
    public float GetValue => value;
    protected void SetValue(float value)
    {
        this.value = value;
        foreach (Action<float> onChange in this.onChangeActions)
        {
            onChange(value);
        }
    }
    protected void AddToValue(float value)
    {
        SetValue(this.value + value);
    }

    [Header("Stats change")]
    [SerializeField]
    protected List<Action<float>> onChangeActions = new List<Action<float>>();

    public void AddOnChangeAction(Action<float> onChange)
    {
        onChangeActions.Add(onChange);
    }
}
