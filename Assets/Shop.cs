using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] BuySell;
    GameObject Display;
    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(transform.forward * 5);

        Display = Instantiate(BuySell[Random.Range(0, BuySell.Length)], transform.position - transform.forward * 6.5f, Quaternion.identity, transform);
        Destroy(Display.GetComponent<FiredFromCannon>());
    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        //     Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        FiredFromCannon FiredFromCannon = other.GetComponent<FiredFromCannon>();
        if (FiredFromCannon != null)
        {
            if (other.name == Display.name)
                FiredFromCannon.Shrink = true;
        }
    }
}
