using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotationToCamera : MonoBehaviour
{
  //  RotationConstraint ThisIsWhereIWouldPutMyRotationConstraint;
    void Update()
    {
     transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward, Camera.main.transform.up);
    //    ThisIsWhereIWouldPutMyRotationConstraint = GetComponent<RotationConstraint>();
    }


}






        //.AddSource(Camera.main, 1)