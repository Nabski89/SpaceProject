using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCarry : MonoBehaviour
{
    int cooldown = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
            cooldown -= 1;
        if (Input.GetKeyDown("e") && transform.childCount == 1 && cooldown < 1)
        {
            Debug.Log("I'm gonnna AHHHHH");
            transform.DetachChildren();
        }
    }

    void OnTriggerStay(Collider other)
    {

        ObjectCarry ObjectHold = other.GetComponent<ObjectCarry>();
        if (ObjectHold != null)
        {

            if (Input.GetKeyDown("e") && transform.childCount == 0)
            {
                Debug.Log("fuck");cooldown = 5;
                other.transform.parent = transform;
                
            }
        }
    }
}
