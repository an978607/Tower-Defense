using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Enemy2; // Tractor
    public GameObject Enemy3; // Enraged farmer

    // How many enemys to create and how many are left to create
    public int totalEnemies = 0;
    private int numEnemies = 0;
    private int spawnedEnemies = 0;

    public bool spawn = true; // spawner will spawn enemies
    public bool spawnWave = false; // true when start button is pressed
    public int totalWaves = 1;
    public int enemySpeed = 5;
    public int level;
    private int numWaves = -1;
    private int waveNumber = 0;
    private float timeSinceLastSpawn = 0.0f;
    [Range(0.0f,2.0f)]
    public float timeToWait;

    // called every frame
    void Update() {
        if (spawn)
        {
            Scene current = SceneManager.GetActiveScene();
            string name = current.name;
            if(name.Equals("Map01"))
            {
                Debug.Log("map is 01");
                this.level = 1;

            } else if(name.Equals("Map02")){
                Debug.Log("map is 02");
                this.level = 2;
            } else if(name.Equals("Map03")){
                this.level = 3;
            } else if(name.Equals("Map04")){
                this.level = 4;
            } else if(name.Equals("Map05")){
                this.level = 5;
            } else{
                Debug.Log("Map is not 1-5");
            }

            spawnForLevel(level);
        }
    }

    private void spawnEnemy()
    {
        GameObject enemy = (GameObject) Instantiate(Enemy, gameObject.transform.position, Quaternion.identity);
        enemy.GetComponent<FollowPath>().speed = enemy.GetComponent<EnemyStats>().speed;
        enemy.GetComponent<FollowPath>().isCopy = true;
        // Increase the number of spawned enemies
        numEnemies++;
    }

//    IEnumerator spawnEnemyCoroutine(GameObject EnemyType){
//        GameObject enemy = (GameObject) Instantiate(EnemyType, gameObject.transform.position, Quaternion.identity);
//        enemy.GetComponent<FollowPath>().speed = enemySpeed;
//        enemy.GetComponent<FollowPath>().isCopy = true;
//        // Increase the number of spawned enemies
//        numEnemies++;
//        yield return new WaitForSeconds(1.0f);
//    }

    public void destroyEnemy()
    {
        numEnemies--;
    }

    // each level has a different number of waves separated by varying amounts of time.
    // each level has multiple enemy types that spawn at different time intervals
    // we want to finish when num enemies becomes 0
    private void spawnForLevel(int level)
    {
        switch(level)
        {
            case(1):
                totalEnemies = 5;
                timeToWait = 1.0f;
                // spawn a wave after time period has passed
                if (spawnWave && timeSinceLastSpawn > timeToWait)
                {
                    // spawn an enemy and reset spawn timer
                    spawnEnemy();
                    spawnedEnemies++;
                    timeSinceLastSpawn = 0.0f;
                }
                // if all enemies of a wave are destroyed, spawn a new wave
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
            case (2):
                totalEnemies = 8;
                timeToWait = 1.0f;
                // spawn a wave after time period has passed
                if (spawnWave && timeSinceLastSpawn > timeToWait)
                {
                    // spawn an enemy and reset spawn timer
                    spawnEnemy();
                    spawnedEnemies++;
                    timeSinceLastSpawn = 0.0f;
                }
                // if all enemies of a wave are destroyed, spawn a new wave
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
