using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGun : MonoBehaviour
{
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
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Ammo = Ammo1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Ammo = Ammo2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Ammo = Ammo3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Ammo = Ammo4;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Ammo = Ammo5;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Ammo = Ammo6;
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Ammo = Ammo7;
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                Ammo = Ammo8;
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                Ammo = Ammo9;
            }

            Vector3 point = new Vector3();
            Vector2 mousePos = new Vector2();

            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;


            point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
           // Debug.Log(point);

            transform.LookAt(point, Vector3.up);


            //  Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.back));

            if (transform.position != transform.parent.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, 0.5f * Time.deltaTime);
            }
            else
                if (Input.GetMouseButtonDown(0))
            {
                GameObject FIRE = Instantiate(Ammo, transform.position + Vector3.back + transform.up, Quaternion.identity, transform.parent.parent);
                FIRE.GetComponent<Rigidbody>().velocity = transform.parent.parent.GetComponent<Rigidbody>().velocity + transform.up;
                transform.position = transform.position - transform.up * 0.5f;
            }
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                Active = true;
            }
        }

    }

    void fivemillionammochecks()
    {

    }
}
