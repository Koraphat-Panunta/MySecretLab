using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunk : MonoBehaviour
{
    public string chunkID;
    public Transform[] attachPoints;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (attachPoints == null) return;

        foreach (var t in attachPoints)
        {
            if (t == null) continue;
            Gizmos.DrawSphere(t.position, 0.1f);
            Gizmos.DrawLine(t.position, t.position + t.forward * 0.5f);
        }
    }
#endif
}
