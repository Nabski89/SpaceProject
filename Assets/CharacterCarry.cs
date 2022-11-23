using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCarry : MonoBehaviour
{
    int cooldown = 5;
    bool CarryAnything = false;
    public CharAnimatorScript AnimateReference;

    // Bit shift the index of the layer (8) to get a bit mask, This would cast rays only against colliders in layer 8.
    int FurniturelayerMask = 1 << 8;
    int ObjectlayerMask = 1 << 7;
    FurnitureCarry FurnitureHold;
    ObjectCarry ObjectHold;
    ObjectSpawn SpawnRayd;

    void FixedUpdate()
    {
        if (cooldown > 0)
            cooldown -= 1;
        if (Input.GetKeyDown("e"))
        {

            RaycastHit hitFurn;
            // Does the ray intersect any objects excluding the player layer
            //     Debug.DrawLine(transform.position + Vector3.back, transform.position - (transform.up * 5) + Vector3.back, Color.white, 10.0f);
            if (Physics.Raycast(transform.position + Vector3.back, -1 * transform.up, out hitFurn, 5, FurniturelayerMask))
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -1 * hitFurn.distance), Color.yellow);
                Debug.Log("Did Hit the furniture" + hitFurn.transform);
                FurnitureHold = hitFurn.transform.GetComponent<FurnitureCarry>();
            }
            else
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -5), Color.green, 10f);
                Debug.Log("Did not Hit a furniture");
            }

            //Now do it again for objects

            RaycastHit hitObj;
            //     Debug.DrawLine(transform.position + Vector3.back, transform.position - (transform.up * 5) + Vector3.back, Color.white, 10.0f);
            if (Physics.Raycast(transform.position + Vector3.back, -1 * transform.up, out hitObj, 5, ObjectlayerMask))
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -1 * hitObj.distance), Color.red);
                Debug.Log("Did Hit the object" + hitObj.transform);
                ObjectHold = hitObj.transform.GetComponent<ObjectCarry>();
            }
            else
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -5), Color.green, 10f);
                Debug.Log("Did not Hit an object");
            }

            if (CarryAnything == true && cooldown < 1)
            {
                //try to place furniture
                var furnicarry = GetComponentInChildren<FurnitureCarry>();
                if (furnicarry != null)
                {
                    furnicarry.DropIt();
                    CarryAnything = false;
                }
                //try to place an object we have on a furniture
                var objicarry = GetComponentInChildren<ObjectCarry>();
                if (FurnitureHold != null && objicarry != null)
                {
                    if (FurnitureHold.gameObject.transform.childCount == 1)
                    {
                        Debug.Log("put this down");
                        objicarry.gameObject.transform.parent = FurnitureHold.transform;
                        objicarry.PlaceIt();
                        CarryAnything = false;
                    }
                }
                //if we managed to drop anything
                if (CarryAnything == false)
                {
                    cooldown = 5;
                    AnimateReference.Drop();
                }
            }
            if (CarryAnything == false && cooldown < 1)
            {
                if (ObjectHold != null)
                {
                    //try to pick up a object
                    {
                        Debug.Log("we got an object");

                        ObjectHold.gameObject.transform.parent = transform;
                        ObjectHold.gameObject.transform.localScale = Vector3.one;
                        ObjectHold.gameObject.transform.position = transform.position - transform.up;
                        //- transform.up/ 2;
                        ObjectHold.gameObject.transform.rotation = transform.parent.rotation;

                        AnimateReference.Grab();
                        cooldown = 5;
                        CarryAnything = true;
                    }
                }
                if (FurnitureHold != null && cooldown < 1)
                {

                    //try to pick up a furniture, but only if it doesn't have stuff on it
                    if (CarryAnything == false && FurnitureHold.gameObject.transform.childCount == 1)
                    {
                        Debug.Log("we got some furniture");

                        FurnitureHold.gameObject.transform.parent = transform;
                        FurnitureHold.gameObject.transform.localScale = Vector3.one * 0.75f;
                        FurnitureHold.gameObject.transform.position = transform.position - transform.up;
                        //- transform.up / 2;
                        FurnitureHold.gameObject.transform.rotation = transform.parent.rotation;

                        AnimateReference.Grab();
                        cooldown = 5;
                        CarryAnything = true;
                    }
                }
            }
        }
        if (Input.GetKey("r"))
        {
            RaycastHit hitSpawn;
            if (Physics.Raycast(transform.position + Vector3.back, -1 * transform.up, out hitSpawn, 5, ObjectlayerMask))
            {
                SpawnRayd = hitSpawn.transform.GetComponent<ObjectSpawn>();

                SpawnRayd.Progress += Time.deltaTime;
                if (SpawnRayd.Progress > SpawnRayd.ProgressReq && CarryAnything == false)
                {
                    Instantiate(SpawnRayd.ObjectToSpawn, transform.position - transform.up, transform.rotation, transform);
                    SpawnRayd.Progress = 0;
                    CarryAnything = true;
                }
            }
        }
    }
}
