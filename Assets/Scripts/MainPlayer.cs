using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Explosion;
    public static GameObject Player;


    private bool isShooting;

    private const float MAXLEFT = -4.7f;
    private const float MAXRIGHT = 4.7f;
    private const float MAXUP = 4.7f;
    private const float MAXDOWN = -7f;

    public float speed = 10;
    private float cooldown = 0.2f;

    public static int currentLives = 3;

    public AudioClip ShootSFX;
    public AudioClip ExplosionSFX;

    private void Start()
    {
        UIManager.UpdateLives(currentLives);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > MAXLEFT)
            transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.W) && transform.position.y < MAXUP)
            transform.Translate(Vector2.up * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.S) && transform.position.y > MAXDOWN)
            transform.Translate(Vector2.down * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < MAXRIGHT)
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        AudioManager.PlaySoundEffect(ShootSFX);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }

    public void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            //take damage
            TakeDamage();
            AudioManager.PlaySoundEffect(ExplosionSFX);
        }
    }

    public static void TakeDamage()
    {
        currentLives--;
        UIManager.UpdateLives(currentLives);

        if (currentLives <= 0)
        {
            //open game over screen
            MenuManager.OpenGameOver();
            SaveManager.SaveProgress();
            //destroy all enemies
            EnemySpawner.DestroyAllEnemies();
        }
    }

    public void AddLife()
    {
        if (currentLives == 3)
        {
            UIManager.UpdateScore(500);
        }
        else
        {
            currentLives++;
            UIManager.UpdateLives(currentLives);
        }
    }

    /*transfor players position when he dies
    public static void TeleportPlayer()
    {
        if (MenuManager.endgame)
        {
            Player.transform.position = new Vector2(8, -6);
            MenuManager.endgame = false;
        }
        else
        {
            Player.transform.position = new Vector2(0, -6);
        }
    }*/

}
