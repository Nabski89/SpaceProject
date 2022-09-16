using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWorld : MonoBehaviour
{
    public GameObject[] Platform;
    public int SpawnCount;
    public float XY;
    public int Scale = 1;
    //I could use transform.parent.position.z but ugh
    public int ZLocation;
    public bool RandomRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        XY = XY * Scale;
        int Count = 0;
        while (Count < SpawnCount)
        {
            //this got split up because it was long
            if (RandomRotation == true)
                Instantiate(Platform[Random.Range(0, Platform.Length)], new Vector3(Random.Range(-XY, XY), Random.Range(-XY, XY), ZLocation), Random.rotation, transform);
            else
                Instantiate(Platform[Random.Range(0, Platform.Length)], new Vector3(Random.Range(-XY, XY), Random.Range(-XY, XY), ZLocation), Quaternion.identity, transform);
            Count += 1;
        }
    }
}