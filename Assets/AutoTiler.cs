using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTiler : MonoBehaviour
{
    // this script is bugged don't use it
//straight outta the fucking manuel
    public GameObject block;
   public int width = 10;
   public int height = 4;
  
   void Start()
   {
       for (int y=0; y<height; ++y)
       {
           for (int x=0; x<width; ++x)
           {
               Instantiate(block, new Vector3(transform.position.x+x,transform.position.y+y,transform.position.z), Quaternion.identity, transform);
           }
       }       
   }
}