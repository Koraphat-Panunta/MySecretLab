using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LeaningRotationManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-1, 1)]
    [SerializeField] private float leaningLeftRightSpline;

    [Range(-1,1)] 
    [SerializeField]private float leaningLeftRightSpline1;

    [Range(0, 2)]
    [SerializeField] private float multiplyleaningLeftRightSpline1;

    [SerializeField] private MultiRotationConstraint rotationConstraintSpline;
    [SerializeField] private MultiRotationConstraint rotationConstraintSpline1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float w = 1 - ((1- leaningLeftRightSpline) / 2);

        WeightedTransformArray leanRef = rotationConstraintSpline.data.sourceObjects;
        leanRef.SetWeight(0, 1 - w);
        leanRef.SetWeight(1, w);

        rotationConstraintSpline.data.sourceObjects = leanRef;

        leaningLeftRightSpline1 = leaningLeftRightSpline * multiplyleaningLeftRightSpline1;
        w = 1 - ((1 - leaningLeftRightSpline1) / 2);

        leanRef.SetWeight(0, 1 - w);
        leanRef.SetWeight(1, w);

        rotationConstraintSpline1.data.sourceObjects = leanRef;
    }
}
