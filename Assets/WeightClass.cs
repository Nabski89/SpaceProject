using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class WeightClass : MonoBehaviour
{
    public Image WeightBar;
    public GameObject MainShip;
    Rigidbody m_Rigidbody;
    Ship MainShipScript;
    void Start()
    {
        //   Debug.Log(GetComponent<Image>());
        WeightBar = GetComponent<Image>();
 //       Debug.Log(WeightBar);
        m_Rigidbody = MainShip.GetComponent<Rigidbody>();
        MainShipScript = MainShip.GetComponent<Ship>();
        WeightBar.fillAmount = m_Rigidbody.mass / (MainShipScript.CargoCapacity + MainShipScript.DefaultCapacity);
    }

    // Update is called once per frame
    void Update()
    {
        WeightBar.fillAmount = m_Rigidbody.mass / (MainShipScript.CargoCapacity + MainShipScript.DefaultCapacity);
    }
}
