using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCarry : MonoBehaviour
{
    int cooldown = 5;
    public bool CarryAnything = false;
    public CharAnimatorScript AnimateReference;

    // Bit shift the index of the layer (8) to get a bit mask, This would cast rays only against colliders in layer 8.
    int FurniturelayerMask = 1 << 8;
    int ObjectlayerMask = 1 << 7;
    public float CarryHeightMULT = 1;
    //I need to clear these out
    FurnitureCarry FurnitureHold;
    ObjectCarry ObjectHold;
    ObjectSpawn SpawnRayd;

    void FixedUpdate()
    {
        if (cooldown > 0)
            cooldown -= 1;
        if (Input.GetKeyDown("e"))
        {
            //clear these out before we cast so we can't pick things back up
            FurnitureHold = null;
            ObjectHold = null;
            SpawnRayd = null;
            RaycastHit hitFurn;
            // Does the ray intersect any objects excluding the player layer
            //     Debug.DrawLine(transform.position + Vector3.back, transform.position - (transform.up * 5) + Vector3.back, Color.white, 10.0f);
            if (Physics.Raycast(transform.position + Vector3.back, -1 * transform.up, out hitFurn, 2, FurniturelayerMask))
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -1 * hitFurn.distance), Color.yellow);
                FurnitureHold = hitFurn.transform.GetComponent<FurnitureCarry>();
                if (FurnitureHold != null)
                    Debug.Log("Did Hit the furniture" + hitFurn.transform);
            }
            else
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -5), Color.green, 10f);
                Debug.Log("Did not Hit a furniture");
            }
            //Now do it again for objects
            RaycastHit hitObj;
            //     Debug.DrawLine(transform.position + Vector3.back, transform.position - (transform.up * 5) + Vector3.back, Color.white, 10.0f);
            if (Physics.Raycast(transform.position + Vector3.back, -1 * transform.up, out hitObj, 2, ObjectlayerMask))
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -1 * hitObj.distance), Color.red);
                ObjectHold = hitObj.transform.GetComponent<ObjectCarry>();
                if (ObjectHold != null)
                    Debug.Log("Did Hit the object we could carry" + hitObj.transform);
            }
            else
            {
                Debug.DrawRay(transform.position + Vector3.back, (transform.up * -5), Color.green, 10f);
                Debug.Log("Did not Hit an object");
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
                        ObjectHold.GetComponentInChildren<ObjectCarry>().GrabIt();
                        AnimateReference.Grab();
                        cooldown = 5;
                        CarryAnything = true;
                    }
                }
                //try to pick up a furniture, but only if it doesn't have stuff on it and we aren't carrying anything
                if (FurnitureHold != null && CarryAnything == false && FurnitureHold.GetComponentInChildren<ObjectCarry>() == null)
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
                    if (FurnitureHold.GetComponentInChildren<ObjectCarry>() == null)
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

        }
        if (Input.GetKey("r"))
        {
            RaycastHit hitActivate;
            if (Physics.Raycast(transform.position + Vector3.back, -1 * transform.up, out hitActivate, 2))
            {
                Debug.Log("Trying to activate a" + hitActivate.transform);
                //gun
                Gun GunRayd = hitActivate.transform.GetComponent<Gun>();
                if (GunRayd != null)
                    GunRayd.Fire();
                //object spawners
                SpawnRayd = hitActivate.transform.GetComponentInChildren<ObjectSpawn>();
                if (SpawnRayd != null)
                {

                    SpawnRayd.Progress += Time.deltaTime;
                    if (SpawnRayd.Progress > SpawnRayd.ProgressReq && CarryAnything == false)
                    {
                        Instantiate(SpawnRayd.ObjectToSpawn, transform.position - transform.up + (transform.forward * CarryHeightMULT), transform.rotation, transform);
                        SpawnRayd.Progress = 0;
                        CarryAnything = true;
                    }
                }


            }
        }
    }
}