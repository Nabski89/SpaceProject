using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMovement : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float Thrust = 1000;
    public bool DriftUP = false;
    public bool DriftRL = false;
    public bool Spin = false;
    public bool SpingWild = false;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (DriftUP == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddForce(transform.up * Thrusty);
        }
        if (DriftRL == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddForce(-transform.right * Thrusty);
        }

        if (Spin == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddTorque(transform.forward * Thrusty * 5);
        }
        if (SpingWild == true)
        {
            float Thrusty = Random.Range(-Thrust, Thrust);
            m_Rigidbody.AddTorque(transform.up * Thrusty * 5);
        }
        Destroy(this);
    }
}