using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VautingNode
{

    MoveAbleObject moveAbleObject;
    ObstacleDetection obstacleDetection;
    Movement movement;
    ParkourVaulting_MotionWarping ParkourVaulting_MotionWarping;
    Vector3 firstCastPos;
    Vector3 secondCastPos;

    Vector3 ct1;
    Vector3 ct2;
    Vector3 exitPos;
    
    public VautingNode(MoveAbleObject moveAbleObject) 
    {
        this.obstacleDetection = moveAbleObject.obstacleDetection;
        this.moveAbleObject = moveAbleObject;
        this.movement = moveAbleObject.movement;
        this.ParkourVaulting_MotionWarping = moveAbleObject.ParkourVaulting_MotionWarping;
        this.firstCastPos = moveAbleObject.firstCastPos.position;
    }

    public void Enter()
    {
        Vector3 startPos = moveAbleObject.transform.position;


        movement.motionWarping
            = movement.StartCoroutine
            (movement.MotionWarpingCurve(
                startPos,
                ct1,
                ct2,
                exitPos,
                ParkourVaulting_MotionWarping.duration,
                ParkourVaulting_MotionWarping.motionCurve
                )
            );
    }

    public void Exit()
    {
        
    }

    public  bool IsReset()
    {
        return movement.motionWarping == null; 
    }

    public  bool PreCondition()
    {
        DrawGuzmoz.enterPos = moveAbleObject.transform.position;

        Vector3 firstCastDir = moveAbleObject.transform.forward;
        Vector3 secondCastDir = Vector3.down;
        Vector3 firstCastDes = firstCastPos +Vector3.up*3;

        if (obstacleDetection.GetEdgeObstaclePos(0.025f, firstCastDir, firstCastPos, firstCastDes, 0.5f, out Vector3 edgePosFirst)) {

            DrawGuzmoz.firstEdgePos = edgePosFirst;

            secondCastPos = edgePosFirst + Vector3.up * 1 +firstCastDir*0.2f;
            Vector3 secondCastDes = secondCastPos + firstCastDir * 3;

            if (obstacleDetection.GetEdgeObstaclePos(0.025f, secondCastDir, secondCastPos, secondCastDes, 0.5f, out Vector3 edgePosSecond)) {

                DrawGuzmoz.secondEdgePos = edgePosSecond;

                ct1 = edgePosFirst + ParkourVaulting_MotionWarping.controlPoint_1_Offset;
                ct2 = edgePosSecond + ParkourVaulting_MotionWarping.controlPoint_2_Offset;
                exitPos = edgePosSecond + ParkourVaulting_MotionWarping.exitPos_Offset;

                DrawGuzmoz.ct1 = ct1;
                DrawGuzmoz.ct2 = ct2;
                DrawGuzmoz.exitPos = exitPos;
                return true;
            }
           return false;
        }
        return false;
    }

    public  void Update()
    {
       
    }

    public  void FixedUpdate()
    {
        
    }
}

