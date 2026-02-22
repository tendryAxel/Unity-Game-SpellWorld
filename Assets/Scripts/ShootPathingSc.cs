using System;
using UnityEngine;

[Serializable]
public class ShootPathingSc
{
    public ShootPathingSc(Vector3 source, Vector3 target, float speed)
    {
        this.source = source;
        this.target = target;
        this.speed = speed;
        this.currentPosition = source;
    }

    [SerializeField]
    private Vector3 source;

    [SerializeField]
    private Vector3 target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 currentPosition;

    public Vector3 GetPosition()
    {
        return currentPosition;
    }
    
    public bool TargetReached()
    {
        return this.TargetReached(currentPosition);
    }

    public bool TargetReached(Vector3 position)
    {
        return (position - source).magnitude >= (target - source).magnitude;
    }

    public void UpdatePosition(out RaycastHit hit, out bool hasHit)
    {
        Vector3 deltaMove = GetDirection() * speed * Time.deltaTime;
        Vector3 nextPosistion = deltaMove + currentPosition;
        if (TargetReached(nextPosistion))
        {
            currentPosition = target;
            hasHit = Physics.Raycast(currentPosition, target, out hit);
            return;
        }
        hasHit = Physics.Raycast(currentPosition, nextPosistion, out hit);
        currentPosition = nextPosistion;
    }

    public void DrawPath()
    {
        Debug.DrawLine(source, target);
    }

    public Vector3 GetDirection()
    {
        return (target - source).normalized;
    }
}
