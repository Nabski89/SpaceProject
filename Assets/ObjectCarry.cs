using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public float DoThingRate = 0;
    public bool Placed = false;
    public bool CookAble = false;
    public float CookAmount = 0;
    public float CookRequirement = 3;
    public GameObject CookedVersion;
    public bool ProcessAble = false;
    public GameObject ProcessVersion;
    public bool FireAble = false;
    public bool PackageAble = false;

    Rigidbody m_Rigidbody;

    //lets start with just cook and process

    //CHOP
    //HAND
    //COOK
    //PORTION
    //WATER

    //process
    //combine
    //cook
    //plate
    //serve

    public void PlaceIt()
    {
        Debug.Log("DROP IT LIKE IT'S HOT");
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -0.85f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = Vector3.one;
        Placed = true;
        if (transform.parent.GetComponentInChildren<Burner>() != null)
            DoThingRate = transform.parent.GetComponentInChildren<Burner>().CookSpeed;
    }
    public void GrabIt()
    {
        Debug.Log("YOU PICKED UP A " + transform);
        Placed = false;
    }
    public void Launch()
    {
        //this tries to put it into the center of the cannon
        transform.position = transform.position+(Vector3.right*0.5f) + (Vector3.down*0.8f) + Vector3.back;
        //then remove the constraints and give it some velocity
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        m_Rigidbody.AddForce(Vector3.right * 500);
        transform.parent = null;
        Destroy(gameObject, 10);
    }
    public void Update()
    {
        if (Placed == true)
        {
            CookAmount += Time.deltaTime * DoThingRate;
            if (CookAmount > CookRequirement)
            {

                GameObject SpawnCooked = Instantiate(CookedVersion, transform.position, Quaternion.identity, transform.parent);
                if (SpawnCooked.GetComponent<ObjectCarry>() != null)
                    SpawnCooked.GetComponent<ObjectCarry>().PlaceIt();
                Destroy(gameObject);
            }
        }
    }
}
