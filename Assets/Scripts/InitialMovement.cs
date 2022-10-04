using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMovement : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float Thrust = 1000;
    //set values
    public bool SetDriftUP = false;
    //randomized values
    public bool RDriftUP = false;
    public bool RDriftRL = false;
    public bool RSpin = false;
    public bool RSpingWild = false;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (SetDriftUP == true)
        {
            m_Rigidbody.AddForce(transform.up * Thrust);
        }
        if (RDriftUP == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddForce(transform.up * Thrusty);
        }
        if (RDriftRL == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddForce(-transform.right * Thrusty);
        }

        if (RSpin == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddTorque(transform.forward * Thrusty * 5);
        }
        if (RSpingWild == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddTorque(transform.up * Thrusty * 5);
        }
        Destroy(this);
    }
}