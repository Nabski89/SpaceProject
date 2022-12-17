using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInitiate : MonoBehaviour
{
    public GameObject DefaultSector;
    public GameObject[] SectorArray;
    public int ScaleFactor = 300;
    // Start is called before the first frame update
    void Start()
    {
        //shuffle the list using this https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        reshuffle(SectorArray);

        Instantiate(SectorArray[0], new Vector3(-1*ScaleFactor, 1*ScaleFactor, 0), Quaternion.identity, transform);
        Instantiate(SectorArray[1], new Vector3(0, 1*ScaleFactor, 0), Quaternion.identity, transform);
        Instantiate(SectorArray[2], new Vector3(1*ScaleFactor, 1*ScaleFactor, 0), Quaternion.identity, transform);
        Instantiate(SectorArray[3], new Vector3(-1*ScaleFactor, 0, 0), Quaternion.identity, transform);
        Instantiate(DefaultSector, new Vector3(0, 0, 0), Quaternion.identity, transform);
        Instantiate(SectorArray[4], new Vector3(1*ScaleFactor, 0, 0), Quaternion.identity, transform);
        Instantiate(SectorArray[5], new Vector3(-1*ScaleFactor, -1*ScaleFactor, 0), Quaternion.identity, transform);
        Instantiate(SectorArray[6], new Vector3(0, -1*ScaleFactor, 0), Quaternion.identity, transform);
        Instantiate(SectorArray[7], new Vector3(1*ScaleFactor, -1*ScaleFactor, 0), Quaternion.identity, transform);

    }

    // Update is called once per frame
    void Update()
    {

    }


    void reshuffle(GameObject[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            GameObject tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
