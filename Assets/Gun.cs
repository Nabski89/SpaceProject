using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Animator mAnimator;
    public GameObject GunSound;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Fire()
    {
        if (GetComponentInChildren<ObjectCarry>() != null)
        {
            Instantiate(GunSound, transform.position, Quaternion.identity);
            mAnimator.SetTrigger("Fire");
            GetComponentInChildren<ObjectCarry>().Launch();
        }
    }
}
