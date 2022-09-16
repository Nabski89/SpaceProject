using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMovement : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float Thrust = 100;
    public bool Drift = true;
    public bool Spin = true;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Thrust = Random.Range(-Thrust, Thrust);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Drift == true)
        {
            m_Rigidbody.AddForce(transform.up * Thrust);
            m_Rigidbody.AddForce(-transform.right * Thrust);
        }
        if (Spin == true)
        {
            m_Rigidbody.AddTorque(transform.forward * Thrust * 5);
        }
     //   Destroy(this);
    }
}