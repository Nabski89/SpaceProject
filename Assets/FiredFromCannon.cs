using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredFromCannon : MonoBehaviour
{
    //8 types and 2 special

    // each has a high and low tier
    //Raw Materials, Furniture, Pets, Crew, Money/Pull
    //rock, chest, table, potion, bug, mushroom, lizard, human

    //Hmmmm I should come up with some kind of pricing and scaling
    //the second of each type is the more expensive one, but how does each group go from one price catagory to the next
    // I could add SIZE+MASS so that you may want to fill up on a bulky thing and a heavy thing or a bunch of medium
    // anyways I'm going with 3x the lower tier, then 80%ish of the high tier of the tier before
    // 15 - 45, 35 - 105, 80 - 240, 190 - 570
    public bool Shrink = false;
    public Ship.AmmunitionEnum AmmoType;
    public int BaseValue;
    public bool PickUpAble = false;
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddTorque(transform.forward * Random.Range(0, 25));
        m_Rigidbody.AddTorque(transform.right * Random.Range(0, 25));
        m_Rigidbody.AddTorque(transform.up * Random.Range(0, 25));
        transform.parent = null;
        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (Shrink == true)
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            transform.position -= Vector3.back * 0.5f;
            if (transform.localScale.x < 0.1)
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Ship ShipHit = other.GetComponent<Ship>();
        if (ShipHit != null && PickUpAble == true)
        {
            if (ShipHit.CargoCapacity + ShipHit.DefaultCapacity + m_Rigidbody.mass > other.GetComponent<Rigidbody>().mass)
            {
                Ship.AmmoCount[AmmoType] += 1;
                other.GetComponent<Rigidbody>().mass += m_Rigidbody.mass;
                Destroy(gameObject);
            }
            else
                Debug.Log("The ship is full");
        }
    }
}
