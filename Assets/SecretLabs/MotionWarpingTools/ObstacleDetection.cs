using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection 
{
    //public ObstacleDetection() { }
    public List<Vector3> GetSurfaceCast(float sphereRaduis, Vector3 castDir, Vector3 startPos, Vector3 destinatePos)
    {
        List<Vector3> sphereCast = new List<Vector3>();
        for (float i = 0; i <= 1; i = i + sphereRaduis * 2)
        {
            Vector3 castPos = Vector3.Lerp(startPos, destinatePos, i);
            if (Physics.SphereCast(castPos, sphereRaduis, castDir, out RaycastHit hit, 10, LayerMask.GetMask("Default"))){
                sphereCast.Add(hit.point);
            }
            else{
                sphereCast.Add(castPos + (castDir * 10));
            }
        }
        return sphereCast;
    }

    public bool GetEdgeObstaclePos(float sphereRaduis, Vector3 castDir, Vector3 startPos, Vector3 destinatePos,float difDistance,out Vector3 edgePos)
    {
        List<Vector3> sphereCast = GetSurfaceCast(sphereRaduis, castDir, startPos, destinatePos);

        edgePos = new Vector3();

        for(int i = 0; i < sphereCast.Count; i++)
        {
            if (i >= sphereCast.Count - 1) return false;

            if (Vector3.Distance(sphereCast[i], sphereCast[i + 1]) >= difDistance){
                edgePos = sphereCast[i];
                break;
            }
        }
        return true;

    }
}
