using UnityEngine;

[CreateAssetMenu(fileName = "impactData", menuName = "Scriptable Objects/impactData")]
public class ImpactData : ScriptableObject
{
    [SerializeField]
    private GameObject impactPrefab;

    [SerializeField]
    private float lifeTimeInSecond;

    public GameObject ImpactPrefab => impactPrefab;

    public float LifeTimeInSecond => lifeTimeInSecond;
}
