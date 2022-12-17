using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInteractWith : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CanvasText;
    public string STRINGY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ActivateMiniGame()
    {
        Debug.Log("Minigame activated on " + transform);
        CanvasText.text = STRINGY;
    }
}
