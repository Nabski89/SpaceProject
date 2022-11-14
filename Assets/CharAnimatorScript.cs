using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
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
}
