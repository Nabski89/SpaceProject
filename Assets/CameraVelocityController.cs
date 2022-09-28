using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVelocityController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_Rigidbody.velocity / 10 + transform.up + Vector3.back * 10+transform.parent.position;
    }
}
