using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredFromCannon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
