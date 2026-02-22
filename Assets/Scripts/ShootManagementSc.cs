using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ShootManagementSc : MonoBehaviour
{
    [SerializeField]
    private List<ShootInstanceSc> shootInstances;

    private List<ShootInstanceSc> toRemove = new List<ShootInstanceSc>();

    void Update()
    {
        foreach (ShootInstanceSc shootInstance in shootInstances)
        {
            shootInstance.Update();
            if (shootInstance.TargetReached())
            {
                toRemove.Add(shootInstance);
            }
        }

        ClearRemoveList();
    }

    void ClearRemoveList()
    {
        if (shootInstances.Count == 0) return;

        foreach (ShootInstanceSc shootInstance in toRemove)
        {
            shootInstance.Delete();
            shootInstances.Remove(shootInstance);
        }

        toRemove.Clear();
    }

    public void AddShoot(ShootData shoot, Vector3 source, Vector3 target)
    {
        GameObject instance = Instantiate(shoot.BulletPrefab);
        shootInstances.Add(new ShootInstanceSc(
            new ShootPathingSc(
                source,
                target,
                shoot.Speed
            ),
            instance,
            shoot
        ));
    }
}
