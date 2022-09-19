using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector3 VelocityTrack;
    Rigidbody m_Rigidbody;
    public float ThrusterValue = 1;
    public float UD_Thrust = 0f;
    public float RL_Thrust = 0f;
    public float Rotate_Thrust = 0f;

    public GameObject RearEngine1;
    public GameObject RearEngine2;
    public GameObject RearEngine3;
    public GameObject ReverseEngine1;
    public GameObject ForwardEngineRight;
    public GameObject ForwardEngineLeft;

    public float timer = 5;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;

        AmmoCount.Add(AmmunitionEnum.Ammo1, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo2, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo3, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo4, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo5, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo6, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo7, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo8, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo9, Random.Range(0, 25));
        AmmoCount.Add(AmmunitionEnum.Ammo0, 5);
    }

    //ammo-cargo things
    public enum AmmunitionEnum { Ammo1, Ammo2, Ammo3, Ammo4, Ammo5, Ammo6, Ammo7, Ammo8, Ammo9, Ammo0 };
    //Make a dictionary with that type, and a quantity
    public static Dictionary<AmmunitionEnum, int> AmmoCount = new Dictionary<AmmunitionEnum, int>();

    float AmmoTimer = 5;
    void Update()
    {
        if (Ship.AmmoCount[Ship.AmmunitionEnum.Ammo0] < 5.0f)
        {
            AmmoTimer -= Time.deltaTime;
            if (AmmoTimer < 0)
            {
                AmmoTimer += 5;
                AmmoCount[AmmunitionEnum.Ammo0] += 1;
            }
        }

        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetKeyDown("w"))
        {
            if (RearEngine1.activeSelf == false)
            {
                UD_Thrust = ThrusterValue;
                RearEngine1.SetActive(true);
            }
            else
            {
                if (RearEngine2.activeSelf == false)
                {
                    UD_Thrust += ThrusterValue;
                    RearEngine2.SetActive(true);
                }
                else
                {
                    if (RearEngine3.activeSelf == false)
                    {
                        UD_Thrust += ThrusterValue;
                        RearEngine3.SetActive(true);
                    }
                }
            }
        }
        if (Input.GetKeyDown("s"))
        {
            ReverseEngine1.SetActive(true);
            RearEngine1.SetActive(false);
            RearEngine2.SetActive(false);
            RearEngine3.SetActive(false);
            UD_Thrust = -ThrusterValue / 10;
        }
        if (Input.GetKeyUp("s"))
        {
            ReverseEngine1.SetActive(false);
            RearEngine1.SetActive(false);
            RearEngine2.SetActive(false);
            RearEngine3.SetActive(false);
            UD_Thrust = 0;
        }

        RL_Thrust = 0;
        if (Input.GetKey("d"))
        {
            RL_Thrust = -ThrusterValue;
        }
        if (Input.GetKey("a"))
        {
            RL_Thrust = ThrusterValue;
        }
        //pitch and yaw
        if (Input.GetKey("q") && ForwardEngineLeft.activeSelf == false)
        {
            ForwardEngineLeft.SetActive(true);
            Rotate_Thrust = ThrusterValue;
        }
        if (Input.GetKey("e") && ForwardEngineRight.activeSelf == false)
        {
            ForwardEngineRight.SetActive(true);
            Rotate_Thrust = -ThrusterValue;
        }

        if (ForwardEngineLeft.activeSelf == true)
        {
            if (Input.GetKey("q"))
            { }
            else
            {
                ForwardEngineLeft.SetActive(false);
                Rotate_Thrust -= ThrusterValue;
            }
        }
        if (ForwardEngineRight.activeSelf == true)
        {
            if (Input.GetKey("e"))
            { }
            else
            {
                ForwardEngineRight.SetActive(false);
                Rotate_Thrust += ThrusterValue;
            }
        }

    }
    void FixedUpdate()
    {



        m_Rigidbody.AddForce(transform.up * UD_Thrust);
        //you shouldn't be using RL for anything but to dock
        m_Rigidbody.AddForce(-transform.right * RL_Thrust / 10);
        m_Rigidbody.AddTorque(transform.forward * Rotate_Thrust / 10);

        /* 
           timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 5;
                UD_Thrust = 0;
                RL_Thrust = 0;
                RearEngine1.SetActive(false);
                RearEngine2.SetActive(false);
                RearEngine3.SetActive(false);
            }
    */

        VelocityTrack = m_Rigidbody.velocity;
    }
}