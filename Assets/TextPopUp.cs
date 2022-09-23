using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public GameObject SomeTextBox;
    TMPro.TextMeshPro FloatingPrice;
    public string STRINGY;
    // Start is called before the first frame update
    int StringLimit = 0;
    void Start()
    {
        FloatingPrice = GetComponentInChildren<TMPro.TextMeshPro>();
        FloatingPrice.text = STRINGY;
        SomeTextBox.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        Ship ShipHit = other.GetComponent<Ship>();
        if (ShipHit != null)
        {
            SomeTextBox.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        Ship ShipHit = other.GetComponent<Ship>();
        if (ShipHit != null)
        {
            FloatingPrice.text = STRINGY.Substring(0, Mathf.Min(StringLimit, STRINGY.Length));
            StringLimit += 1;
        }
    }


    void OnTriggerExit(Collider other)
    {
        Ship ShipHit = other.GetComponent<Ship>();
        if (ShipHit != null)
        {
            StringLimit = 0;
            SomeTextBox.SetActive(false);
        }
    }
}
