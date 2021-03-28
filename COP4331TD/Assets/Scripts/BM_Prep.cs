using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BM_Prep : MonoBehaviour
{
    public GameObject Spawner;
    public int startingBalance;

    // store the starting balance in case the user quits
    void Start(){
       startingBalance = PlayerPrefs.GetInt("CurrentBalance"); 
       Debug.Log("Starting balance " + startingBalance);
    }

    public void BackButtonPressed()
    {
        // return the starting currency and go back to level selection screen
        PlayerPrefs.SetInt("CurrentBalance", startingBalance);
        SceneManager.LoadScene("LevelSelection");
    }

    public void StartButtonPressed()
    {
        //Spawner.GetComponent<Spawn>().spawnWave = true;
        Spawner.GetComponent<Spawn2>().spawnWave = true;
        Time.timeScale = 1f;
    }
}
