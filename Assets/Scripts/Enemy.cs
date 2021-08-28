using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scorevalue;

    public GameObject lifePrefab;

    public GameObject explosion;

    public AudioClip EnemyExplosionSFX;
    public AudioClip PlayerExplosionSFX;


    private const int LIFE_CHANCE = 10;

    //powerUp or something chance
    //private const int CHANCE = 000;

    public void kill()
    {
        UIManager.UpdateScore(scorevalue);

        int ran = Random.Range(0, 100);
        if (ran == LIFE_CHANCE)
            Instantiate(lifePrefab, transform.position, Quaternion.identity);

        Instantiate(explosion, transform.position, Quaternion.identity);
        AudioManager.PlaySoundEffect(EnemyExplosionSFX);

        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            //Destroy enemy ship
            Destroy(gameObject);
            //Play ship explosion
            collision.gameObject.GetComponent<MainPlayer>().PlayExplosion();
            //Play explosion sound effect 
            AudioManager.PlaySoundEffect(PlayerExplosionSFX);
            //take one life away from player
            MainPlayer.TakeDamage();
        }
    }
}
