using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    // How many enemys to create and how many are left to create
    public int totalEnemies = 0;
    private int numEnemies = 0;

    public bool spawn = true; // spawner will spawn enemies
    public bool spawnWave = false;
    public int totalWaves = 1;
    private int numWaves = 0;
    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        if (spawn)
        {
            if (numWaves < totalWaves + 1)
            {
                timeSinceLastSpawn += Time.deltaTime;
                if (spawnWave && timeSinceLastSpawn > 0.5f)
                {
                    // spawn an enemy
                    spawnEnemy();
                    timeSinceLastSpawn = 0.0f;
                }
                if (numEnemies == 0)
                {
                    timeSinceLastSpawn = 0.5f;
                    // start spawning wave
                    spawnWave = true;
                    // increase the number of waves
                    numWaves++;
                    // reset enemies
                    numEnemies = 0;
                }
                if (numEnemies == totalEnemies)
                {
                    spawnWave = false;
                }
            }
        }
    }

    void spawnEnemy()
    {
        GameObject enemy = (GameObject) Instantiate(Enemy, gameObject.transform.position, Quaternion.identity);
        enemy.GetComponent<FollowPath>().speed = 5;
        // Increase the number of spawned enemies
        numEnemies++;
    }
}
