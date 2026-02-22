using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellSc : MonoBehaviour
{
    [SerializeField]
    private List<ShootData> shoots;

    [SerializeField]
    private int currentShootId = 0;

    public ShootData GetCurrentShootData()
    {
        return shoots[currentShootId];
    }
}
