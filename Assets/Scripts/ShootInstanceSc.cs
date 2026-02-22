using System;
using UnityEngine;

[Serializable]
public class ShootInstanceSc
{
    public ShootInstanceSc(ShootPathingSc shootPathing, GameObject bulletObj, ShootData data)
    {
        this.shootPathing = shootPathing;
        this.bulletObj = bulletObj;
        this.data = data;
    }

    [SerializeField]
    private ShootPathingSc shootPathing;

    [SerializeField]
    private GameObject bulletObj;

    private RaycastHit hit;
    private bool hasHit;
    private ShootData data;

    public void Update()
    {
        shootPathing.UpdatePosition(out hit, out hasHit);
        bulletObj.transform.position = shootPathing.GetPosition();
        shootPathing.DrawPath();
        ApplyHitAction();
    }

    void ApplyHitAction()
    {
        if (hasHit)
        {
            hit.rigidbody.AddForce(shootPathing.GetDirection() * (float) SpellUtils.ManaContentToForce(data.Mana));
        }
    }

    public void Delete()
    {
        GameObject.Destroy(bulletObj);
    }

    public bool TargetReached()
    {
        return hasHit || shootPathing.TargetReached();
    }
}
