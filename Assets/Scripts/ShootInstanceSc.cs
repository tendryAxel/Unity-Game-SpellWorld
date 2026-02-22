using System;
using UnityEngine;

[Serializable]
public class ShootInstanceSc
{
    public ShootInstanceSc(ShootPathingSc shootPathing, GameObject bulletObj)
    {
        this.shootPathing = shootPathing;
        this.bulletObj = bulletObj;
    }

    [SerializeField]
    private ShootPathingSc shootPathing;

    [SerializeField]
    private GameObject bulletObj;

    public void Update()
    {
        shootPathing.UpdatePosition();
        bulletObj.transform.position = shootPathing.GetPosition();
        shootPathing.DrawPath();
    }

    public void Delete()
    {
        GameObject.Destroy(bulletObj);
    }

    public bool TargetReached()
    {
        return shootPathing.TargetReached();
    }
}
