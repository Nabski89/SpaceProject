using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipResources : MonoBehaviour
{

    public static ShipResources Instance;
    public static float Money = 100;
    public static float Mass = 0;
    public static float Resource1 = 0;
    public static float Resource2 = 0;

    public static Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public static void ResourceUpdate(float CACHING)
    {
        Resource1 += CACHING;
        Mass = m_Rigidbody.mass;
        ResUI.Instance.ResourceUpdate();
    }

}
