using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class pickup1 : MonoBehaviour
{
    public float fallspeed;

    public AudioClip WeaponPickupSFX;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallspeed);
    }

    public abstract void pickweaponUp();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
            AudioManager.PlaySoundEffect(WeaponPickupSFX);
            pickweaponUp();
    }
}
