using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTiler : MonoBehaviour
{
    // this script is bugged don't use it
    //straight outta the fucking manuel
    public GameObject block;
    public GameObject wall;
    public float width = 10;
    public float height = 4;
    public GameObject Camera;

    void Start()
    {
        //camera wants width/2 and height /6 -3
        width += 1;
        height += 1;
        for (int y = 0; y < height + 1; ++y)
        {
            for (int x = 0; x < width + 1; ++x)
            {
                //the edges
                if (y == 0 || y == height || x == 0 || x == width)
                {
                    if (x == 0 && y != 0 && y != height)
                        Instantiate(wall, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z - 0.16f), Quaternion.Euler(0, 0, -90), transform);
                    if (x == width && y != 0 && y != height)
                        Instantiate(wall, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z - 0.16f), Quaternion.Euler(0, 0, 90), transform);
                    if (y == 0 && x != 0 && x != width)
                        Instantiate(wall, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z - 0.16f), Quaternion.identity, transform);
                    if (y == height && x != 0 && x != width)
                        Instantiate(wall, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z - 0.16f), Quaternion.Euler(0, 0, -180), transform);


                }
                else
                    Instantiate(block, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z), Quaternion.identity, transform);
            }
        }
    }
}