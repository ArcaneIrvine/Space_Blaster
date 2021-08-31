using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scorevalue;

    public GameObject lifePrefab;
    public GameObject weaponchangeprefab;
    public GameObject explosion;

    public AudioClip EnemyExplosionSFX;
    public AudioClip PlayerExplosionSFX;


    private const int LIFE_CHANCE = 2;

    private const int WEAPON_CHANCE = 2;

    public void kill()
    {
        UIManager.UpdateScore(scorevalue);

        int liferan = Random.Range(0, 80);
        int bulletran = Random.Range(0, 50);

        if (liferan == LIFE_CHANCE)
            Instantiate(lifePrefab, transform.position, Quaternion.identity);

        if(bulletran ==WEAPON_CHANCE)
            Instantiate(weaponchangeprefab, transform.position, Quaternion.identity);

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
