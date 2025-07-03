using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRootMotionBetweenAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip animationClip;

    [Range(0, 1)]
    [SerializeField] private float enableRootMotionOffset;

    [SerializeField] private float _timer;

    [SerializeField] private bool _enableRootMotion;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = false;
    }
    void Start()
    {
        animator.CrossFade("Kick", .1f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= animationClip.length * enableRootMotionOffset)
            _enableRootMotion = true;


    }
    private void OnAnimatorMove()
    {
        Debug.Log("animator.DeltaPosition = " + animator.deltaPosition);

        if(_enableRootMotion == false)
            return;
        transform.position += animator.deltaPosition;
        transform.rotation *= animator.deltaRotation;
    }
}
