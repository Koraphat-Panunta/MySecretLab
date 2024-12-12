using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionBound : MonoBehaviour
{
    public Collider collider;
    public float extensX;
    public float extensY;
    public float extensZ;

    public float size_X;
    public float size_Y;
    public float size_Z;

    private void Start()
    {
        if(TryGetComponent<BoxCollider>(out BoxCollider boxCollider))
        {
            collider = boxCollider;
        }
        else
        {
            collider = GetComponent<Collider>();
        }
    }
    private void OnDrawGizmos()
    {
        //extensX = collider.bounds.extents.x;
        //extensY = collider.bounds.extents.y;
        //extensZ = collider.bounds.extents.z;

        //size_X = collider.bounds.size;
        Vector3[] coverPoints = new Vector3[4];
        if(collider.TryGetComponent<BoxCollider>(out BoxCollider Collider)) 
        {
            if (collider.transform.rotation.x % 360 != 0 || collider.transform.rotation.z % 360 != 0)
            {
                coverPoints[0] = collider.bounds.center + new Vector3(collider.bounds.extents.x, 0, collider.bounds.extents.z);
            }
            else
            {
                coverPoints[0] = Collider.bounds.center + Vector3.Cross(collider.transform.forward, Vector3.up).normalized * (Collider.size.x / 2)
                + Vector3.Cross(Vector3.up, collider.transform.right).normalized * (Collider.size.z / 2);
            }
        }
        else
        {
            coverPoints[0] = collider.bounds.center + new Vector3(collider.bounds.extents.x, 0, collider.bounds.extents.z);
        }
        //coverPoints[1] = collider.bounds.center + new Vector3(collider.bounds.extents.x, 0, -collider.bounds.extents.z); // back-right
        //coverPoints[2] = collider.bounds.center + new Vector3(-collider.bounds.extents.x, 0, collider.bounds.extents.z); // front-left
        //coverPoints[3] = collider.bounds.center + new Vector3(collider.bounds.extents.x, 0, collider.bounds.extents.z); // fornt-right

       

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(coverPoints[0],0.1f); // Red
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);

        //Gizmos.color = Color.green;
        //Gizmos.DrawSphere(coverPoints[1], 0.1f); // Green

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(coverPoints[2], 0.1f); // Yellow

        //Gizmos.color = Color.blue;
        //Gizmos.DrawSphere(coverPoints[3], 0.1f); // Blue
    }
}
