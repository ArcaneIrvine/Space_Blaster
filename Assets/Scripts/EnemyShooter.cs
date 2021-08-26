using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyprojectile;
    public static List<GameObject> enemies = new List<GameObject>();
    private float shootTimer = 1f;
    private const float shootTime = 1f;

    public AudioClip EnemyFireSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            enemies.Add(go);

        if (shootTimer <= 0)
        {
            Shoot();
        }
        shootTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        Vector2 pos = enemies[Random.Range(0, enemies.Count)].transform.position;
        Instantiate(enemyprojectile, pos, Quaternion.identity);
        AudioManager.PlaySoundEffect(EnemyFireSFX);
        shootTimer = shootTime;
    }
}
