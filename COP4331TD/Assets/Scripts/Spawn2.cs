using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn2 : MonoBehaviour
{
    public GameObject Enemy; // basic
    public GameObject Enemy2; // tractor
    public GameObject Enemy3; // enraged
    public GameObject manager;

    public Transform spawnPoint;

    public int level = 0;

    public int numWaves = 0;
    public bool spawnWave = false;
    public float timeBetweenWaves = 5f;
    public int waveNumber = -1;
    private float countdown = 2f;


    public int totalEnemies = 0;
    public int enemiesAlive = 0;
    public int enemiesLeftToSpawn = 0;

    public float speed = 10f; // temporary speed for all enemies

    public int[] numEnemiesForMap = new int[]{5, 8, 12, 19, 121};
    public int[] numWavesForMap = new int[]{1, 2, 3, 3, 5};

    public int[] enemyArray;
    
    private int lives;
    //public int[] enemySubWave;



    // At the start of the level, get the active scene, which tells you how many enemies there are.
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

        // Print out map information for debugging
        enemiesLeftToSpawn = totalEnemies;
        Debug.Log("current map: " + current.name + " current level: " + this.level +  " number of waves: " + numWaves + " total enemies: " + totalEnemies + " enemies left to spawn: " +enemiesLeftToSpawn);
    }

    // Update is called once per frame
    // If the user pressed start, spawnWave is active and countdown for the next wave begins.
    void Update()
    {
        if(spawnWave){
            // all enemies spawned and made it to end
            if(enemiesLeftToSpawn <= 0 && enemiesAlive <= 0 && manager.GetComponent<startLevel>().currentLives <= 0){
                Debug.Log("You lost this level!");
                SceneManager.LoadScene("LevelSelection");
                //Application.Quit(); // temporary for now
            }

            // all enemies spawned and have been defeated.
            else if(enemiesLeftToSpawn <= 0 && enemiesAlive <= 0){
                Debug.Log("You won this level!");
                SceneManager.LoadScene("LevelSelection");
                //Application.Quit(); // temporary for now
            }

            // more enemies to spawn
            if(enemiesLeftToSpawn > 0 && countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }

            // pause between waves.
            countdown -= Time.deltaTime;
        }
    }

    // A coroutine that spawns the wave for the level
    IEnumerator SpawnWave()
    {
        // determine the current wave number
        waveNumber++;
        Debug.Log("Spawning wave");

        // Spawn the enemies corresponding to the level and wave
        switch(level)
        {
            // 5 farmers
            case(1):
                for(int i = 0; i < totalEnemies; i++){
                    SpawnEnemy(1);
                    enemiesLeftToSpawn--;
                    enemiesAlive++;
                    Debug.Log("enemies left to spawn: " + enemiesLeftToSpawn + " enemies alive: " + enemiesAlive);
                    yield return new WaitForSeconds(1.0f);
                }
                break;

            // 2 subwaves of two tractors and 2 farmers
            case(2):
                for(int i = 0; i < 4; i++){

                    if(i == 0 || i == 1){
                    SpawnEnemy(1); // two farmers
                    } else if(i == 2){
                        SpawnEnemy(3); // 1 enraged farmer
                    } else{
                        SpawnEnemy(2); // 1 tractor
                    }

                    enemiesLeftToSpawn--;
                    enemiesAlive++;

                    Debug.Log("enemies left to spawn: " + enemiesLeftToSpawn + " enemies alive: " + enemiesAlive);
                    yield return new WaitForSeconds(1.0f);

                }
                break;

            // 3 waves (2FT, 1 EF), (1 FT, 2 EF), (5F, 1 EF)
            case(3):

                // establish waves in 2D array of enemies
                enemyArray = new int[]{2, 2, 3, 2, 3, 3, 1, 1, 1, 1, 1, 3};
                if(waveNumber == 0){
                    Debug.Log("wave" + waveNumber);
                    for(int i = 0; i < 3; i++){
                        SpawnEnemy(enemyArray[i]);
                        enemiesLeftToSpawn--;
                        enemiesAlive++;

                        Debug.Log("enemies left to spawn: " + enemiesLeftToSpawn + " enemies alive: " + enemiesAlive);
                        yield return new WaitForSeconds(1.0f);
                    }
                }  else if(waveNumber == 1)
                {
                Debug.Log("wave" + waveNumber);
                    for(int i = 3; i < 6; i++){
                        SpawnEnemy(enemyArray[i]);
                        enemiesLeftToSpawn--;
                        enemiesAlive++;

                        Debug.Log("enemies left to spawn: " + enemiesLeftToSpawn + " enemies alive: " + enemiesAlive);
                        yield return new WaitForSeconds(1.0f);
                    }
                } else if(waveNumber == 2){
                   Debug.Log("wave" + waveNumber);
                    for(int i = 6; i < 12; i++){
                        SpawnEnemy(enemyArray[i]);
                        enemiesLeftToSpawn--;
                        enemiesAlive++;

                        Debug.Log("enemies left to spawn: " + enemiesLeftToSpawn + " enemies alive: " + enemiesAlive);
                        yield return new WaitForSeconds(1.0f);
                    }
                } else{
                    Debug.Log("Shouldn't spawn anything for this wave.");
                }

                yield return new WaitForSeconds(2.0f);
                break;

            case(4):
                enemyArray = new int[]{2, 2, 3, 3, 3, 3, 2, 1, 1, 1, 2, 1, 3, 2, 1, 3, 2, 1, 3};


                break;
            case(5):
                // TO DO
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
