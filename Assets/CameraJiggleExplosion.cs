using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJiggleExplosion : MonoBehaviour
{
    public bool explosionOn = false;
    public float explosionStr = 1;
    public float explosionCount = 3;
    public Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionOn == true && explosionCount > 0)
        {
            explosionCount -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.up * Random.Range(-1.0f, 1.0f)) + (Vector3.right * Random.Range(-1.0f, 1.0f)) + (Vector3.forward * Random.Range(-1.0f, 1.0f)), explosionStr);
        }
        else
        {
            explosionOn = false;
            transform.position = StartPosition;
        }

    }
}
