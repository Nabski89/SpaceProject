using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Position;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;
        if (Input.GetKey("up"))
        {
            Position.y += Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            Position.y -= Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            Position.x -= Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            Position.x += Time.deltaTime;
        }
        transform.position = Position;
    }
}
