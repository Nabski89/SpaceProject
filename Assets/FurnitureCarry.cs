using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCarry : MonoBehaviour
{
    public void DropIt()
    {
        Debug.Log("DROP IT LIKE IT'S HOT");
        transform.parent = null;
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -0.5f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = Vector3.one;
    }
}
