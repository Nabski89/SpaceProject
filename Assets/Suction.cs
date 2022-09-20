using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
    }


    void Update()
    {
        transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        if (transform.localScale.x > 4)
            Destroy(gameObject);
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        FiredFromCannon FiredFromCannon = other.GetComponent<FiredFromCannon>();
        if (FiredFromCannon != null)
        {
            Rigidbody m_Rigidbody = other.GetComponent<Rigidbody>();
            Debug.Log(m_Rigidbody.mass);
            m_Rigidbody.AddTorque(transform.forward * 5000);
            m_Rigidbody.AddForce(-30 * m_Rigidbody.mass * GetComponent<Rigidbody>().velocity);
            //change the layer to default because the default layer doesn't collide with the ship
            FiredFromCannon.PickUpAble = true;
        }
    }
}
