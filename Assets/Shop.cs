using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] BuySell;

    GameObject Display;

    public float Price = 1;
    public int StockNumber;
    public float StockHave;
    public float StockWant;
    TMPro.TextMeshPro FloatingPrice;


    void Start()
    {
        FloatingPrice = GetComponentInChildren<TMPro.TextMeshPro>();
        GetComponent<Rigidbody>().AddTorque(transform.forward * 5);
        StockNumber = Random.Range(0, BuySell.Length);
        Display = Instantiate(BuySell[StockNumber], transform.position - transform.forward * 6.5f, Quaternion.identity, transform);
        Price = Display.GetComponent<FiredFromCannon>().BaseValue;
        Destroy(Display.GetComponent<FiredFromCannon>());
        StockWant = Random.Range(5, 10);
        StockHave = Random.Range(0, StockWant * 2);
    }
    void Update()
    {
        int Display = Mathf.RoundToInt(Price * (StockWant + 5f) / (StockHave + 5f));
        FloatingPrice.text = Display.ToString();

    }
    void OnTriggerEnter(Collider other)
    {
        FiredFromCannon FiredFromCannon = other.GetComponent<FiredFromCannon>();
        if (FiredFromCannon != null)
        {
            //either subtract the money if it is the same type, or add the money and spawn the object if it was money fired
            if (other.name == Display.name && FiredFromCannon.PickUpAble == false)
            {
                FiredFromCannon.Shrink = true;
                Ship.AmmoCount[Ship.AmmunitionEnum.Ammo9] += Mathf.RoundToInt(Price * (StockWant + 5f) / (StockHave + 5f));
                StockHave += 1;
            }
            if (FiredFromCannon.AmmoType == Ship.AmmunitionEnum.Ammo9)
            {
                //check that the ship will still have money and that it isn't the last one in stock
                if (StockHave > 0 && Ship.AmmoCount[Ship.AmmunitionEnum.Ammo9] - (Mathf.RoundToInt(Price * (StockWant + 5f) / (StockHave + 5f))) > 0)
                {
                    Ship.AmmoCount[Ship.AmmunitionEnum.Ammo9] -= Mathf.RoundToInt(Price * (StockWant + 5f) / (StockHave + 5f));
                    GameObject Purchase = Instantiate(BuySell[StockNumber], new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity, transform);
                    Purchase.GetComponent<FiredFromCannon>().PickUpAble = true;
                    StockHave -= 1;
                    Destroy(other.gameObject);
                }
            }

        }
    }
}
