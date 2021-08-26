using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife1 : pickup
{
    public override void pickMeUp()
    {
        GameObject.FindGameObjectWithTag("Ship").GetComponent<MainPlayer>().AddLife();
        Destroy(gameObject);
    }
}
