using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon1 : pickup1
{
    public override void pickweaponUp()
    {
        GameObject.FindGameObjectWithTag("Ship").GetComponent<MainPlayer>().ChangeBullet();
        Destroy(gameObject);
    }

}
