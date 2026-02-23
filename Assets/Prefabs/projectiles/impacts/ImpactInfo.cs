using UnityEngine;

public class ImpactInfo
{
    private float start;

    [SerializeField]
    private GameObject impactInstance;

    public float Start => start;
    public GameObject ImpactInstance => impactInstance;

    public ImpactInfo(float start, GameObject impactInstance)
    {
        this.start = start;
        this.impactInstance = impactInstance;
    }
}
