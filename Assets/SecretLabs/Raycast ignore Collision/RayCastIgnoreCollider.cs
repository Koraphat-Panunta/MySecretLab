using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastIgnoreCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    private LayerMask layerMask_A;
    private LayerMask layerMask_B;
    private LayerMask layerMask_Final;
    public GameObject targetPos;
    void Start()
    {
        layerMask_A = LayerMask.GetMask("Default");
        layerMask_B = LayerMask.GetMask("Obstacle");
        layerMask_Final = LayerMask.GetMask("Default", "Obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, (targetPos.transform.position-transform.position).normalized,out RaycastHit hitInfo,1000,layerMask+layerMask_A))
        {
            Debug.DrawLine(transform.position, hitInfo.point);
        }
        else
        {
            Debug.DrawLine(transform.position, hitInfo.point);
        }
        Debug.Log(layerMask_A.ToString() + " = " + layerMask_A.value);
        Debug.Log(layerMask_B.ToString() + " = " + layerMask_B.value);
        Debug.Log(layerMask_A.ToString() + " + " + layerMask_B.ToString() + " = " + (layerMask_A.value + layerMask_B.value));
        Debug.Log(layerMask_Final.ToString() + " = " + layerMask_Final.value);
        if(layerMask_A+layerMask_B == layerMask_Final)
        {
            Debug.Log("it equal");
        }
    }
}
