using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMesh : MonoBehaviour
{
    public Mesh[] MeshArray;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Mesh mesh2 = Instantiate(mesh);
        GetComponent<MeshFilter>().sharedMesh = MeshArray[Random.Range(0, MeshArray.Length)];

    //    RandomRange[0, MeshArray.Length];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
