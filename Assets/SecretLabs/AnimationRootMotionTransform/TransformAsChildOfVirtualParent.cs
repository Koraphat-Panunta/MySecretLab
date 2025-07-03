using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformAsChildOfVirtualParent 
{
    /// <summary>
    /// Moves childTransform as if it were parented under a virtual fake parent moving and rotating
    /// from startParentPosition/startParentDirection → finalParentPosition/finalParentDirection at t ∈ [0,1].
    /// initialChildOffset and initialChildRotationOffset should be captured at start of interaction.
    /// </summary>
    public static void ApplyVirtualParentTransform(
        Transform childTransform,
        Vector3 startParentPosition,
        Vector3 startParentDirection,
        Vector3 finalParentPosition,
        Vector3 finalParentDirection,
        float t,
        Vector3 initialChildOffset,
        Quaternion initialChildRotationOffset)
    {
        // Interpolate fake parent position
        Vector3 parentPos = Vector3.Lerp(startParentPosition, finalParentPosition, t);

        // Interpolate fake parent rotation from start → final direction
        Quaternion startRot = Quaternion.LookRotation(startParentDirection.normalized, Vector3.up);
        Quaternion finalRot = Quaternion.LookRotation(finalParentDirection.normalized, Vector3.up);
        Quaternion parentRot = Quaternion.Slerp(startRot, finalRot, t);

        // Apply child's initial local offset relative to fake parent
        Vector3 childWorldPos = parentPos + parentRot * initialChildOffset;
        Quaternion childWorldRot = parentRot * initialChildRotationOffset;

        childTransform.position = childWorldPos;
        childTransform.rotation = childWorldRot;
    }
}
