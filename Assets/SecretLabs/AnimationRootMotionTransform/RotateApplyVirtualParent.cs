using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateApplyVirtualParent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform testSubjetc1;
    [SerializeField] private Transform testSubjetc2;

    [SerializeField] private Transform target;

    [Range(0, 1)]
    [SerializeField] private float anchorWeight;

    [SerializeField] private Vector3 anchorPos;
    private Vector3 anchorDir => (testSubjetc2.position - testSubjetc1.position).normalized;

    private Vector3 startParentPos;
    private Vector3 startParentDir;
    private Vector3 finalParentPos;
    private Vector3 finalParentDir;

    [SerializeField] private Vector3 pointingTargetDir => (target.position - anchorPos).normalized;

    [Range(0, 360)]
    [SerializeField] private float pointingTargetOffset;

    private CoreVirtualAnchor coreVirtualAnchor;
    private void Awake()
    {
        coreVirtualAnchor = new CoreVirtualAnchor(anchorPos,Quaternion.LookRotation(anchorDir));
    }
    void Start()
    {
        startParentPos = coreVirtualAnchor.GetAnchorPosition();
        startParentDir = coreVirtualAnchor.GetAnchorRotation() * Vector3.forward;

        coreVirtualAnchor.AddChildTransform(testSubjetc1);
        coreVirtualAnchor.AddChildTransform(testSubjetc2);

        finalParentPos = startParentPos;

    }
    float t = 0;

    // Update is called once per frame
    void Update()
    {
        coreVirtualAnchor.UpdateCoreVirtualAnchorTransform();

        t += Time.deltaTime*0.8f;
        t = Mathf.Clamp01(t);
        finalParentDir = Quaternion.AngleAxis(pointingTargetOffset, Vector3.up) * pointingTargetDir;

        Vector3 anchorPos = Vector3.Lerp(startParentPos,finalParentPos,t);
        Vector3 anchorDir = Vector3.Lerp(startParentDir,finalParentDir,t);

        coreVirtualAnchor.SetAnchorPosition(anchorPos);
        coreVirtualAnchor.SetAnchorRotation(Quaternion.LookRotation(anchorDir));

        if(t >= 1)
        {
            coreVirtualAnchor.Clear();
        }
       
    }
    private void OnValidate()
    {
        anchorPos = Vector3.Lerp(testSubjetc1.position,testSubjetc2.position,anchorWeight);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(anchorPos,.15f);

        Gizmos.color= Color.blue;
        Gizmos.DrawLine(anchorPos, anchorPos + anchorDir * 1);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(anchorPos,anchorPos + (Quaternion.AngleAxis(pointingTargetOffset, Vector3.up) * pointingTargetDir)*1);
    }

}
