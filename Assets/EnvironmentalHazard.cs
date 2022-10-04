using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalHazard : MonoBehaviour
{

    public bool SlowField = false;
    void OnTriggerEnter(Collider other)
    {
        Ship ShipHit = other.GetComponent<Ship>();
        if (ShipHit != null)
        {
            if (SlowField == true)
                ShipHit.GetComponent<Rigidbody>().drag += 0.5f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Ship ShipHit = other.GetComponent<Ship>();
        if (ShipHit != null)
        {
            if (SlowField == true)
                ShipHit.GetComponent<Rigidbody>().drag -= 0.5f;
        }
    }
}
