using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VaultingMotion Data",menuName =("ParkourMotion Dara/Vaulting"))]
public class ParkourVaulting_MotionWarping : ScriptableObject
{
    public Vector3 controlPoint_1_Offset; //ผลต่างตำแหน่งControl Point1 กับ EdgePos1
    public Vector3 controlPoint_2_Offset; //ผลต่างตำแหน่งControl Point2 กับ EdgePos2 
    public Vector3 exitPos_Offset;

    public float duration;
    public AnimationCurve motionCurve;

}
