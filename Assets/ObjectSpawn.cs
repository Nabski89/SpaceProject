using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject ProgressBar;
    public float Progress = 0;
    public float ProgressReq = 2;
    public float ProgressDecay = 0.5f;

    // Update is called once per frame
    void Start()
    {
        var newScale = new Vector3(0, 0, 0);
        ProgressBar.transform.localScale = newScale;
    }
    void FixedUpdate()
    {
        if (Progress > 0)
        {
            Progress -= ProgressDecay * Time.deltaTime;

            var newScale = new Vector3(Mathf.Min(Progress / ProgressReq, 1), .1f, .1f);

            ProgressBar.transform.localScale = newScale;
        }
        else
        {
            var newScale = new Vector3(0, 0, 0);
            ProgressBar.transform.localScale = newScale;
        }

    }
}
