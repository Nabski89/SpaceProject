using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public GameObject WorldCamera;
    public GameObject ShipCamera;
    public GameObject Character;
    public GameObject ShipButton;
    public ShipInteractWorldMap ShipTalkScript;
    public Ship ShipMoveScript;
    // Start is called before the first frame update
    public void Sit()
    {
        ShipCamera.SetActive(false);
        Character.SetActive(false);
        ShipTalkScript.enabled = true;
        ShipMoveScript.enabled = true;
        ShipButton.SetActive(true);
        WorldCamera.SetActive(true);
    }
}
