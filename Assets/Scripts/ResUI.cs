using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResUI : MonoBehaviour
{
    public static ResUI Instance;
    void Start()
    {
        Instance = this;
        ResourceUpdate();
    }
    public void ResourceUpdate()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
         "Money: " + ShipResources.Money.ToString("0") +
         "\nMass: " + ShipResources.Mass.ToString("0") +
         "\nCargo1: " + ShipResources.Resource1.ToString("0") +
         "\nCargo2: " + ShipResources.Resource2.ToString("0");
    }
}