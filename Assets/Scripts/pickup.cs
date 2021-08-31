using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class pickup : MonoBehaviour
{
    public float fallspeed;

    public AudioClip LifePickupSFX;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallspeed);
    }

    public abstract void pickMeUp();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
            AudioManager.PlaySoundEffect(LifePickupSFX);
            pickMeUp();
    }
}
