using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMerchant : MonoBehaviour
{
    // Start is called before the first frame update
    int StockHave = 1;
    int Price = 1;
    float UD_Thrust = 0;
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        FiredFromCannon FiredFromCannon = other.GetComponent<FiredFromCannon>();
        if (FiredFromCannon != null)
        {

            /* this stuff was pull from SHOP and might be cool to do mini trades with
                        //either subtract the money if it is the same type, or add the money and spawn the object if it was money fired
                        if (other.name == Display.name && FiredFromCannon.PickUpAble == false)
                        {
                            FiredFromCannon.Shrink = true;
                            Ship.AmmoCount[Ship.AmmunitionEnum.Ammo9] += Mathf.RoundToInt(Price * (StockWant + 5f) / (StockHave + 5f));
                            StockHave += 1;
                        }
            */
            if (FiredFromCannon.AmmoType == Ship.AmmunitionEnum.Ammo9)
            {
                //check that the ship will still have money and that it isn't the last one in stock
                if (StockHave > 0 && Ship.AmmoCount[Ship.AmmunitionEnum.Ammo9] - Mathf.RoundToInt(Price) > 0)
                {

                    Ship.AmmoCount[Ship.AmmunitionEnum.Ammo9] -= Mathf.RoundToInt(Price);
                    StockHave -= 1;
                    Destroy(other.gameObject);
                    UD_Thrust = 100;
                    Destroy(transform.parent.gameObject, 1);
                    transform.parent = null;
                    Destroy(gameObject, 20);
                }
            }
        }
    }

    void FixedUpdate()
    {
        m_Rigidbody.AddForce(transform.up * UD_Thrust);
    }
}
