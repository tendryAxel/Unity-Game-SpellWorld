using System;
using UnityEngine;

[Serializable]
public class ShootPathingSc
{
    public ShootPathingSc(Vector3 source, Vector3 target)
    {
        this.source = source;
        this.target = target;
        this.speed = 2;
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

    public void UpdatePosition()
    {
        Vector3 deltaMove = (target - source).normalized * speed * Time.deltaTime;
        Vector3 nextPosistion = deltaMove + currentPosition;
        if (TargetReached(nextPosistion))
        {
            currentPosition = target;
            return;
        }
        currentPosition = nextPosistion;
    }

    public void DrawPath()
    {
        Debug.DrawLine(source, target);
    }
}
