using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ImpactManagementSc : MonoBehaviour
{
    private List<ImpactInfo> impacts = new List<ImpactInfo>();

    public void AddImpact(ImpactData impactData, Vector3 position)
    {
        ImpactInfo impact = new ImpactInfo(
            Time.time,
            Instantiate(impactData.ImpactPrefab, position, Quaternion.identity)
        );
        impacts.Add(impact);
        StartCoroutine(this.RemovePointAfterDelay(impact, impactData.LifeTimeInSecond));
    }

    private IEnumerator RemovePointAfterDelay(ImpactInfo impact, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(impact.ImpactInstance);
        impacts.Remove(impact);
    }
}
