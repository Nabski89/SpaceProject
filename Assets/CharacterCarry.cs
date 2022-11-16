using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCarry : MonoBehaviour
{
    int cooldown = 5;
    public CharAnimatorScript AnimateReference;

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
            cooldown -= 1;
        if (Input.GetKeyDown("e") && transform.childCount == 1 && cooldown < 1)
        {
            var furnicarry = GetComponentInChildren<FurnitureCarry>();
            if (furnicarry != null)
                furnicarry.DropIt();


 //           CounterSpace PlaceIt = other.GetComponent<CounterSpace>();
            var objicarry = GetComponentInChildren<ObjectCarry>();
            if (objicarry != null)
            {
                objicarry.PlaceIt();
            }
            AnimateReference.Drop();
        }
    }

    void OnTriggerStay(Collider other)
    {


        FurnitureCarry FurnitureHold = other.GetComponent<FurnitureCarry>();
        ObjectCarry ObjectHold = other.GetComponent<ObjectCarry>();

        if (ObjectHold != null)
        {
            if (Input.GetKeyDown("e") && transform.childCount == 0)
            {
                Debug.Log("we got an object");
                cooldown = 5;
                other.transform.parent = transform;
                other.transform.localScale = Vector3.one * 0.5f;
                other.transform.position = transform.position;
                other.transform.rotation = transform.parent.rotation;
                AnimateReference.Grab();
            }
        }
        if (FurnitureHold != null && transform.childCount == 0)
        {

            if (Input.GetKeyDown("e") && transform.childCount == 0)
            {
                Debug.Log("we got some furniture");
                cooldown = 5;
                other.transform.parent = transform;
                other.transform.localScale = Vector3.one * 0.5f / transform.localScale.x;
                other.transform.position = transform.position;
                other.transform.rotation = transform.parent.rotation;
                AnimateReference.Grab();
            }
        }
        /*

                */
    }
}
