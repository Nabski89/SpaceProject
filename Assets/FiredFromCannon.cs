using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredFromCannon : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Shrink = false;
    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(transform.forward * Random.Range(0, 25));
        GetComponent<Rigidbody>().AddTorque(transform.right * Random.Range(0, 25));
        GetComponent<Rigidbody>().AddTorque(transform.up * Random.Range(0, 25));
        transform.parent = null;
        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (Shrink == true)
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            transform.position -= Vector3.back*0.5f;
            if (transform.localScale.x < 0.1)
                Destroy(gameObject);
        }
    }
}
