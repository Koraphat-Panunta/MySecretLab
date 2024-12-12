using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class MotionDisplay : MonoBehaviour
{
    [SerializeField] private Transform cubeTransform;
    public Vector2 enterPosOffset;
    [SerializeField] private ParkourVaulting_MotionWarping parkourVaulting;
    private void OnDrawGizmos()
    {
        if (cubeTransform != null
            && parkourVaulting != null)
        {
            Vector3 firstEdgePos = cubeTransform.position
                + Vector3.forward * cubeTransform.localScale.z / 2
                + Vector3.up * cubeTransform.localScale.y / 2;

            Vector3 secondEdgePos = cubeTransform.position
                + Vector3.back * cubeTransform.localScale.z / 2
                + Vector3.up * cubeTransform.localScale.y / 2;

            Vector3 ct1 = firstEdgePos + parkourVaulting.controlPoint_1_Offset;
            Vector3 enterPos = firstEdgePos + new Vector3(0, enterPosOffset.y, enterPosOffset.x);
            Vector3 ct2 = secondEdgePos + parkourVaulting.controlPoint_2_Offset;
            Vector3 exitPos = secondEdgePos + parkourVaulting.exitPos_Offset;

            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(cubeTransform.position,cubeTransform.transform.localScale);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(firstEdgePos, 0.1f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(secondEdgePos, 0.1f);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(ct1, 0.1f);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(ct2, 0.1f);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(enterPos, 0.1f);

            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(exitPos, 0.1f);

            Handles.DrawBezier(enterPos, exitPos, ct1, ct2, Color.green, EditorGUIUtility.whiteTexture, 2);
        }
    }
}
