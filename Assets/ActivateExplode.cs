using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExplode : MonoBehaviour
{
    public int explodePower = 1;
    public GameObject ExplodeSound;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var cameras in FindObjectsOfType<Camera>())
        {
            if (cameras.GetComponent<CameraJiggleExplosion>() != null)
            {
                cameras.GetComponent<CameraJiggleExplosion>().explosionOn = true;
                cameras.GetComponent<CameraJiggleExplosion>().explosionCount = explodePower;
                Instantiate(ExplodeSound, transform.position, Quaternion.identity);
            }
        }
        Destroy(this);
    }
}
