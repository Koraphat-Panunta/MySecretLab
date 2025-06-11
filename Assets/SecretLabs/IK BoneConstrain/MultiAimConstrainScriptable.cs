using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultiAimConstrainScriptable", menuName = "ScriptableObjects/MultiAimConstrainScriptable")]
public class MultiAimConstrainScriptable : ScriptableObject
{
    [Range(0, 1)]
    public float weight;

    public Vector3 offset;
}
