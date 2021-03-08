using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour {

    public GameObject Enemy;
    // How many enemys to create and how many are left to create
    public int totalEnemies = 0;
    private int numEnemies = 0;
    private int spawnedEnemies = 0;

    public bool spawn = true; // spawner will spawn enemies
    public bool spawnWave = false;
    public int totalWaves = 1;
    public int enemySpeed = 5;
    public int level;
    private int numWaves = -1;
    private float timeSinceLastSpawn = 0.0f;
    [Range(0.0f,2.0f)]
    public float timeToWait;

    void Update() {
        if (spawn)
        {
            Scene current = SceneManager.GetActiveScene();
            string name = current.name;
            if(name.Equals("Map01"))
            {
                this.level = 1;
            }
            
            spawnForLevel(level);
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

    private void spawnForLevel(int level)
    {
        switch(level)
        {
            case(1):
                timeToWait = 1.0f;
                totalEnemies = 5;
                if (spawnWave && timeSinceLastSpawn > timeToWait)
                {
                    // spawn an enemy
                    spawnEnemy();
                    spawnedEnemies++;
                    timeSinceLastSpawn = 0.0f;
                }
                else if (numEnemies == 0 && spawnWave == true)
                {
                    // increase the number of waves
                    numWaves++;
                    spawnedEnemies = 0;
                }
                else if (spawnedEnemies == totalEnemies)
                {
                    spawnWave = false;
                    spawnedEnemies = 0;
                    timeSinceLastSpawn += Time.deltaTime;
                }
                else
                {
                    timeSinceLastSpawn += Time.deltaTime;
                }
                break;
        }

    }
}
