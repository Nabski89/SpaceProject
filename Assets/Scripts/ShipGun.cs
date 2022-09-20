using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGun : MonoBehaviour
{
    public Ship.AmmunitionEnum AmmoType;
    public GameObject Ammo1;
    public GameObject Ammo2;
    public GameObject Ammo3;
    public GameObject Ammo4;
    public GameObject Ammo5;
    public GameObject Ammo6;
    public GameObject Ammo7;
    public GameObject Ammo8;
    public GameObject Ammo9;
    public GameObject Ammo0;

    public GameObject GunSound;
    GameObject Ammo;
    bool Active = false;
    // Start is called before the first frame update
    void Start()
    {
        Ammo = Ammo1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
            if (Input.GetKeyDown("space"))
            {
                Active = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Ammo = Ammo0;
                AmmoType = Ship.AmmunitionEnum.Ammo0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Ammo = Ammo1;
                AmmoType = Ship.AmmunitionEnum.Ammo1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Ammo = Ammo2;
                AmmoType = Ship.AmmunitionEnum.Ammo2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Ammo = Ammo3;
                AmmoType = Ship.AmmunitionEnum.Ammo3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Ammo = Ammo4;
                AmmoType = Ship.AmmunitionEnum.Ammo4;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Ammo = Ammo5;
                AmmoType = Ship.AmmunitionEnum.Ammo5;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Ammo = Ammo6;
                AmmoType = Ship.AmmunitionEnum.Ammo6;
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Ammo = Ammo7;
                AmmoType = Ship.AmmunitionEnum.Ammo7;
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                Ammo = Ammo8;
                AmmoType = Ship.AmmunitionEnum.Ammo8;
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                Ammo = Ammo9;
                AmmoType = Ship.AmmunitionEnum.Ammo9;
            }

            Vector3 point = new Vector3();
            Vector2 mousePos = new Vector2();

            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;

            point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.parent.position.z - Camera.main.transform.position.z));



            //left up back
            transform.LookAt(point, Vector3.left);

            // Debug.Log(point);
            //  Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.back));

            if (transform.position != transform.parent.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, 0.5f * Time.deltaTime);
            }
            else
                if (Input.GetMouseButton(0))
            {
                if (Ship.AmmoCount[AmmoType] > 0)

                {
                    if (AmmoType != Ship.AmmunitionEnum.Ammo9)
                    {
                        // don't reduce the money ammo on fire, only when it hits the shop
                        Ship.AmmoCount[AmmoType] -= 1;
                    }
                    GameObject FIRE = Instantiate(Ammo, transform.position + transform.forward, Quaternion.identity, transform.parent.parent);
                    Rigidbody RB = FIRE.GetComponent<Rigidbody>();
                    RB.velocity = transform.parent.parent.GetComponent<Rigidbody>().velocity + transform.forward;
                    transform.position = transform.position - transform.forward * 0.5f * RB.mass;
                    if (FIRE.GetComponent<FiredFromCannon>() == true)
                        FIRE.GetComponent<FiredFromCannon>().AmmoType = AmmoType;
                    if (AmmoType == Ship.AmmunitionEnum.Ammo0)
                    {
                        RB.velocity = transform.parent.parent.GetComponent<Rigidbody>().velocity + transform.forward + transform.forward;
                    }
                    GameObject GunSoundPEW = Instantiate(GunSound, transform.position, Quaternion.identity);
                    GunSoundPEW.GetComponent<AudioSource>().volume = 1 - ((4- RB.mass) / 4);
                    
                }
            }

            //transform forward right up
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                Active = true;
            }
            transform.LookAt(transform.parent.parent.position, Vector3.left);
        }

    }

    void fivemillionammochecks()
    {

    }
}
