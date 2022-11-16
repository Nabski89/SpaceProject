using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public void PlaceIt()
    {
        Debug.Log("DROP IT LIKE IT'S HOT");
        transform.parent = null;
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -.75f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = Vector3.one;
    }
}
