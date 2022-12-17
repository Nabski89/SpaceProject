using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInteractWorldMap : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public ShipInteractWith InteractWith;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown("r"))
        {
            //this is way too strict of a requirement
            if (m_Rigidbody.velocity.x == 0 && m_Rigidbody.velocity.y == 0)
            {
                Debug.Log("The ship has gone to interact with something");
                if (InteractWith != null)
                InteractWith.ActivateMiniGame();
                //initiate minigame
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        ShipInteractWith WeHit = other.GetComponent<ShipInteractWith>();
        if (WeHit != null)
        {
            InteractWith = WeHit;
        }
    }

    void OnTriggerExit(Collider other)
    {
        ShipInteractWith WeLeave = other.GetComponent<ShipInteractWith>();
        if (WeLeave != null)
        {
            InteractWith = null;
        }
    }


}