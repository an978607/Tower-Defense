using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BM_Prep : MonoBehaviour
{
    public GameObject Spawner;

    public void BackButtonPressed()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void StartButtonPressed()
    {
        Spawner.GetComponent<Spawn>().spawnWave = true;
        Spawner.GetComponent<Spawn2>().spawnWave = true;
        Time.timeScale = 1f;
    }
}
