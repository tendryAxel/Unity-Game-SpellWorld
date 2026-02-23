using UnityEngine;

[CreateAssetMenu(fileName = "ShootData", menuName = "Scriptable Objects/ShootData")]
public class ShootData : ScriptableObject
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private ImpactData impactData;

    [SerializeField]
    private float speed;

    [SerializeField]
    private long mana;

    public GameObject BulletPrefab => bulletPrefab;
    public ImpactData ImpactData => impactData;
    public float Speed => speed;
    public long Mana => mana;
}