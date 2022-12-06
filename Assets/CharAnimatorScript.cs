using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator mAnimator;
    Rigidbody rb;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) < .1)
            StopMove();
        else
            Walking();

    }
    public void Walking()
    {
        mAnimator.SetTrigger("Moving");
    }
    public void Grab()
    {
        mAnimator.SetTrigger("Grab");
    }
    public void Drop()
    {
        mAnimator.SetTrigger("Drop");
    }
    public void StopMove()
    {
        mAnimator.SetTrigger("StopMove");
    }


}
