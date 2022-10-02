using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiShopDuplicates : MonoBehaviour
{
    public Shop Shop1;
    public Shop Shop2;
    public Shop Shop3;
    public Shop Shop4;
    void Start()
    {
        int Shop1Num = Random.Range(0, 8);
        Shop1.StartUpFromParent(Shop1Num);

        int Shop2Num = Shop1Num;
        while (Shop2Num == Shop1Num)
        {
            Shop2Num = Random.Range(0, 8);
        }
        Shop2.StartUpFromParent(Shop2Num);

        int Shop3Num = Shop1Num;
        while (Shop3Num == Shop1Num || Shop3Num == Shop2Num)
        {
            Shop3Num = Random.Range(0, 8);
        }
        Shop3.StartUpFromParent(Shop3Num);

        int Shop4Num = Shop1Num;
        while (Shop4Num == Shop1Num || Shop4Num == Shop2Num || Shop4Num == Shop3Num)
        {
            Shop4Num = Random.Range(0, 8);
        }
        Shop4.StartUpFromParent(Shop4Num);
        Destroy(this);
    }
}
