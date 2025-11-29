using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class AnimationSampler : MonoBehaviour
{
    [Header("Target")]
    public Animator animator;               // The Animator with the avatar/rig
    public AnimationClip animationClip;     // The clip to sample
    public Animation animation;

    [Header("Sampling Control")]
    [Range(0f, 1f)]
    public float normalizedTime = 0f;       // The current sample time (0–1)
    public bool resetToTPoseAfterSample = false;

    [Header("Root Motion")]
    [SerializeField] private bool isManualRootMotionEnable = false;
    [SerializeField] private bool isCaptureAnchorRoot;
    private Vector3 lastFrameRootPosition;
    private Quaternion lastFrameRootRotation;
    private bool hasLastFrame = false;

    private void OnValidate()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animation.clip = animationClip;
        SampleAnimationAt(normalizedTime);
    }

    public void SampleAnimationAt(float normalizedTime)
    {
        if (animationClip == null || animator == null)
            return;

        normalizedTime = Mathf.Clamp01(normalizedTime);
        float clipTime = animationClip.length * normalizedTime;

        // Cache the current root transform to restore it after sampling
        Vector3 cachedPos = animator.transform.position;
        Quaternion cachedRot = animator.transform.rotation;


        // Temporarily sample the animation to get the new pose (including root motion)
        animationClip.SampleAnimation(animator.gameObject, clipTime);

        if (isManualRootMotionEnable)
        {
            if (isCaptureAnchorRoot == false)
            {
                animator.transform.position = cachedPos;
                animator.transform.rotation = cachedRot;

                lastFrameRootPosition = animator.transform.position;
                lastFrameRootRotation = animator.transform.rotation;

                isCaptureAnchorRoot = true;

            }
        }
        else
        {
            animator.transform.position = cachedPos;
            animator.transform.rotation = cachedRot;
            isCaptureAnchorRoot = false;
        }
       




#if UNITY_EDITOR
        // Force scene update in edit mode
        EditorApplication.QueuePlayerLoopUpdate();
        SceneView.RepaintAll();
#endif

        // Optional reset to prevent animator controller influence
        if (resetToTPoseAfterSample)
            animator.Update(0f);
    }

    public void ResetRootMotionTracking()
    {
        hasLastFrame = false;
    }
}
