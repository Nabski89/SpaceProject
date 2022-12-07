using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public GameObject WorldCamera;
    public GameObject ShipCamera;
    public GameObject Character;
    public GameObject ShipButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sit()
    {
        ShipCamera.SetActive(false);
        Character.SetActive(false);
        ShipButton.SetActive(true);
        WorldCamera.SetActive(true);
    }
}
