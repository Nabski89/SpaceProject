using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Position;
    public Vector3 newDirection;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;

        //move then change rotation



        if (Input.GetKey("right"))
        {
            Position.x += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("up"))
        {
            Position.y += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey("left"))
        {
            Position.x -= Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey("down"))
        {
            Position.y -= Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        //haha doing these one by one seems like bait but whatever
        if (Input.GetKey("up") && Input.GetKey("right"))
            transform.rotation = Quaternion.Euler(0, 0, 45);
        if (Input.GetKey("up") && Input.GetKey("left"))
            transform.rotation = Quaternion.Euler(0, 0, 135);
        if (Input.GetKey("down") && Input.GetKey("left"))
            transform.rotation = Quaternion.Euler(0, 0, 225);
        if (Input.GetKey("down") && Input.GetKey("right"))
            transform.rotation = Quaternion.Euler(0, 0, 315);

        transform.position = Position;

    }
}
