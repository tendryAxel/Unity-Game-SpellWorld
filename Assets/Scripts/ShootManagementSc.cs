using System;
using UnityEngine;

public class ShootManagementSc : MonoBehaviour
{
    [SerializeField]
    private ShootPathingSc shootPathing;

    [SerializeField]
    private GameObject bulletObj;

    void Update()
    {
        shootPathing.UpdatePosition();
        bulletObj.transform.position = shootPathing.GetPosition();
        shootPathing.DrawPath();
    }
}
