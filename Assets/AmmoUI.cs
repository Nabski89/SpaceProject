using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    // Start is called before the first frame update

    public Ship.AmmunitionEnum Reference;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = Ship.AmmoCount[Reference].ToString("0");
    }
}
