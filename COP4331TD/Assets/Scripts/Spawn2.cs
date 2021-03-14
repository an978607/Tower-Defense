using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn2 : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public Transform spawnPoint;

    public int level = 0;

    public int numWaves = 0;
    public bool spawnWave = true;
    public float timeBetweenWaves = 5f;
    public int waveNumber = 0;
    private float countdown = 2f;

    public int totalEnemies = 0;
    public int enemiesAlive = 0;
    public int enemiesLeftToSpawn = 0;

    public float speed = 10f; // temporary speed for all enemies

    public int[] numEnemiesForMap = new int[]{5, 8, 12, 19, 121}; 
    public int[] numWavesForMap = new int[]{1, 2, 3, 3, 5};

    // helps choose the next enemy to span
    //public int[][] waveEnemies = new[5][]{{1, 1, 1, 1, 1}, {}}

    void Start()
    {
        // determine the level
        Scene current = SceneManager.GetActiveScene();
        string name = current.name;

        if(name.Equals("Map01"))
        {
            totalEnemies = numEnemiesForMap[0]; 
            numWaves = numWavesForMap[0];
            this.level = 1;
        } else if(name.Equals("Map02")){
            totalEnemies = numEnemiesForMap[1]; 
            numWaves = numWavesForMap[1];
            this.level = 2;
        } else if(name.Equals("Map03")){
            totalEnemies = numEnemiesForMap[2]; 
            numWaves = numWavesForMap[2];
            this.level = 3;
        } else if(name.Equals("Map04")){
            totalEnemies = numEnemiesForMap[3]; 
            numWaves = numWavesForMap[3];
            this.level = 4;
        } else if(name.Equals("Map05")){
            totalEnemies = numEnemiesForMap[4]; 
            numWaves = numWavesForMap[4];
            this.level = 5;
        } else{
            Debug.Log("Couldn't get map selection");
            Application.Quit();
        }
        
        enemiesLeftToSpawn = totalEnemies;
        Debug.Log("current map: " + current.name + " current level: " + this.level +  " number of waves: " + numWaves + " total enemies: " + totalEnemies + " enemies left to spawn: " +enemiesLeftToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesLeftToSpawn <= 0 && enemiesAlive <= 0){
            Debug.Log("You won this level!");
            SceneManager.LoadScene("LevelSelection");
            Application.Quit(); // temporary for now
        }
        if(enemiesLeftToSpawn > 0 && countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    // A coroutine that spawns the wave for the level
    IEnumerator SpawnWave()
    {
        waveNumber++;
        Debug.Log("Spawning wave");
        
//        for(int i = 0; i < waveNumber; i++)
//        {
//            SpawnEnemy();
//            enemiesLeftToSpawn--;
//            enemiesAlive++;
//            yield return new WaitForSeconds(1.0f);
//        }
        switch(level)
        {
            case(1):
                for(int i = 0; i < totalEnemies; i++){
                    SpawnEnemy(1);
                    enemiesLeftToSpawn--;
                    enemiesAlive++;
                    Debug.Log("enemies left to spawn: " + enemiesLeftToSpawn + " enemies alive: " + enemiesAlive);
                    yield return new WaitForSeconds(1.0f);
                }
                break;
            // must update so that i can spawn only the number of enemies per wave
            case(2):
                for(int i = 0; i < 4; i++){
                    SpawnEnemy(2); // hard coded enemy 2
                    enemiesLeftToSpawn--;
                    enemiesAlive++;
                    Debug.Log("enemies left to spawn: " + enemiesLeftToSpawn + " enemies alive: " + enemiesAlive);
                    yield return new WaitForSeconds(1.0f);
                }
                break;
        }
    }

    void SpawnEnemy(int EnemyType)
    {
        GameObject enemy;
        switch(EnemyType){
            case(1):
                enemy = (GameObject) Instantiate(Enemy, gameObject.transform.position, Quaternion.identity);
                break;
            case(2):
                enemy = (GameObject) Instantiate(Enemy2, gameObject.transform.position, Quaternion.identity);
                break;
            case(3):
                enemy = (GameObject) Instantiate(Enemy3, gameObject.transform.position, Quaternion.identity);
                break;
            default:
            // default to type 1
                enemy = (GameObject) Instantiate(Enemy, gameObject.transform.position, Quaternion.identity);
                break;
        }
        
        //Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponent<FollowPath>().speed = speed;
        enemy.GetComponent<FollowPath>().isCopy = true;
    }

    public void destroyEnemy()
    {
        enemiesAlive--;
        Debug.Log("Destroyed enemy");
    }
}
