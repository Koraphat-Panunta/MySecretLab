using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawGuzmoz : MonoBehaviour
{
    public static Vector3 firstEdgePos;
    public static Vector3 secondEdgePos;
    public static Vector3 ct1;
    public static Vector3 ct2;
    public static Vector3 enterPos;
    public static Vector3 exitPos;
    private void OnDrawGizmos()
    {

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(firstEdgePos, 0.1f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(secondEdgePos, 0.2f);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(ct1, 0.1f);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(ct2, 0.2f);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(enterPos, 0.1f);

            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(exitPos, 0.1f);

            Handles.DrawBezier(enterPos, exitPos, ct1, ct2, Color.green, EditorGUIUtility.whiteTexture, 2);
        }
    }

