using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorInitiate : MonoBehaviour
{
    public GameObject StationObj;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(StationObj, new Vector3(Random.Range(-100.0f, 100.0f)+transform.position.x, Random.Range(-100.0f, 100.0f)+transform.position.y, 50), Quaternion.identity, transform);
    }
}
