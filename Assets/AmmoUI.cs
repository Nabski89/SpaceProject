using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text =
 "1:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo1].ToString("0") +
 "  2:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo2].ToString("0") +
 "  3:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo3].ToString("0") +
 "  4:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo4].ToString("0") +
 "  5:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo5].ToString("0") +
 "  6:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo6].ToString("0") +
 "  7:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo7].ToString("0") +
 "  8:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo8].ToString("0") +
 "  9:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo9].ToString("0") +
 "  0:" + Ship.AmmoCount[Ship.AmmunitionEnum.Ammo0].ToString("0");
    }
}
