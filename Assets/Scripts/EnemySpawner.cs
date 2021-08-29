using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    float maxSpawnRateInSeconds = 3f;

    bool callonceA = true;
    bool callonceB = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.spawn)
        {
            Invoke("SpawnEnemy", maxSpawnRateInSeconds);

            //increase spawn rate every 30 seconds
            InvokeRepeating("IncreaseSpawnRate", 0f, 30f);

            MenuManager.spawn = false;
        }

        else if (MenuManager.endspawn)
        {
            CancelInvoke("SpawnEnemy");
            CancelInvoke("IncreaseSpawnRate");

            MenuManager.endspawn = false;
        }
    }

    //spawn enemy
    void SpawnEnemy()
    {
        //bottom-left point of screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top-right point of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantiate enemy
        int v = Random.Range(0, enemies.Count);
        GameObject anEnemy = (GameObject)Instantiate(enemies[v]);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //Schedule when to spawn next enemy
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            //pick a number between 1 and maxspawnrateinseconds
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;
        Invoke("SpawnEnemy", spawnInSeconds);
    }

    //function to increase difficulty
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

    //Destroy all Enemies when player goes to Main Menu
    public static void DestroyAllEnemies()
    {
        GameObject[] allenemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in allenemies)
            GameObject.Destroy(enemy);
    }
}
