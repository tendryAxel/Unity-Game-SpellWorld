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

    [Header("Stats change")]
    [SerializeField]
    private List<Action> onChangeActions;
}
