using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour
{
    float DefaultScale;
    // Start is called before the first frame update
    void Start()
    {
        DefaultScale = transform.localScale.x;
        transform.localScale = Vector3.one * Random.Range(0, DefaultScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0.5)
            transform.localScale = Vector3.forward + Vector3.right * DefaultScale + Vector3.up * DefaultScale;
        else
            transform.localScale -= new Vector3(0.0005f, 0.0005f, 0);
    }
}
