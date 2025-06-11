using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class MultiAimConstrainManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MultiAimConstrainScriptable multiAimConstrainScriptable;
    [SerializeField] private MultiAimConstraint MultiAimConstraint;

    public void Update()
    {
        MultiAimConstraint.weight = multiAimConstrainScriptable.weight;
        MultiAimConstraint.data.offset = multiAimConstrainScriptable.offset;
    }
    private void OnValidate()
    {
        if(this.MultiAimConstraint == null)
            this.MultiAimConstraint = GetComponent<MultiAimConstraint>();
    }
}
