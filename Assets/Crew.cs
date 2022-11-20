using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    Rigidbody rb;
    public float playerSpeed = 1.0f;
    public CharAnimatorScript AnimateReference;

    /*
        public Vector3 Position;
        public Vector3 newDirection;
        */
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        rb.velocity = move * playerSpeed;
        // if we are faster than half speed start to move
        /*
        if (Mathf.Abs(rb.velocity) > Vector.Zero) ;
        {
            AnimateReference.Walking();
        }
        */
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            transform.rotation = Quaternion.Euler(180, 0, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg);
    }
}