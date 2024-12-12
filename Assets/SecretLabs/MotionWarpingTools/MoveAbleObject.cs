using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveAbleObject : MonoBehaviour
{
    public VautingNode vautingNode;
    public Movement movement;
    public ObstacleDetection obstacleDetection;
    public ParkourVaulting_MotionWarping ParkourVaulting_MotionWarping;
    public Transform firstCastPos;
    bool isVaulting;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        obstacleDetection = new ObstacleDetection();
        vautingNode = new VautingNode(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && isVaulting == false)
        {
            if (vautingNode.PreCondition())
            {
                isVaulting = true;
                vautingNode.Enter();
                animator.CrossFade("Vaulting", 0.05f, 0);
            }
        }
        if(isVaulting == true)
        {
            vautingNode.Update();
            if (vautingNode.IsReset())
            {
                isVaulting = false;
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        
    }
}
