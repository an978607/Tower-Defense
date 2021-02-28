using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Enemy;
    // How many enemys to create and how many are left to create
    public int totalEnemies = 0;
    private int numEnemies = 0;
    private int spawnedEnemies = 0;

    public bool spawn = true; // spawner will spawn enemies
    public bool spawnWave = false;
    public int totalWaves = 1;
    public int enemySpeed = 5;
    private int numWaves = -1;
    private float timeSinceLastSpawn = 0.0f;
    [Range(0.0f,2.0f)]
    public float timeToWait;

    void Update() {
        if (spawn)
        {
            if (numWaves < totalWaves + 1)
            {
                timeSinceLastSpawn += Time.deltaTime;
                if (spawnWave && timeSinceLastSpawn > timeToWait)
                {
                    // spawn an enemy
                    spawnEnemy();
                    spawnedEnemies++;
                    timeSinceLastSpawn = 0.0f;
                }
                if (numEnemies == 0)
                {
                    // start spawning wave
                    spawnWave = true;
                    // increase the number of waves
                    numWaves++;
                    spawnedEnemies = 0;
                    print(numWaves);
                }
                if (spawnedEnemies == totalEnemies)
                {
                    spawnWave = false;
                }
            }
        }
    }

    private void spawnEnemy()
    {
        GameObject enemy = (GameObject) Instantiate(Enemy, gameObject.transform.position, Quaternion.identity);
        enemy.GetComponent<FollowPath>().speed = enemySpeed;
        enemy.GetComponent<FollowPath>().isCopy = true;
        // Increase the number of spawned enemies
        numEnemies++;
    }

    public void destroyEnemy()
    {
        numEnemies--;
    }
}
