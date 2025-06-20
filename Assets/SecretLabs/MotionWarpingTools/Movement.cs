using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public CharacterController characterController;

    public Coroutine motionWarping;
    public IEnumerator MotionWarpingCurve(
        Vector3 start, 
        Vector3 cT1, 
        Vector3 cT2,
        Vector3 exit, 
        float duration, 
        AnimationCurve animationCurve)
    {
        float elapsedTime = 0f; // Track the elapsed time of the motion

        // Ensure we have a valid CharacterController
        if (characterController == null)
        {
            Debug.LogError("CharacterController is not assigned.");
            yield break;
        }

        while (elapsedTime < duration)
        {
            // Calculate normalized time (0 to 1)
            float t = elapsedTime / duration;

            // Apply animation curve to smooth the motion
            float smoothedT = animationCurve.Evaluate(t);

            // Compute position along the cubic B�zier curve using the smoothed parameter
            Vector3 position = CalculateBezierPoint(smoothedT, start, cT1, cT2, exit);

            // Move the character to the computed position
            Vector3 delta = position - characterController.transform.position;
            characterController.Move(delta);

            // Increment time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Ensure the character reaches the final exit position
        Vector3 finalPosition = CalculateBezierPoint(1f, start, cT1, cT2, exit);
        Vector3 finalDelta = finalPosition - characterController.transform.position;
        characterController.Move(finalDelta);

        motionWarping = null;
    }

    // Helper method to calculate a point on a cubic B�zier curve
    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point = uuu * p0; // (1 - t)^3 * P0
        point += 3 * uu * t * p1; // 3 * (1 - t)^2 * t * P1
        point += 3 * u * tt * p2; // 3 * (1 - t) * t^2 * P2
        point += ttt * p3;        // t^3 * P3

        return point;
    }
}
