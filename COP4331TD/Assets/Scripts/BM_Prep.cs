using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BM_Prep : MonoBehaviour
{
 public void BackButtonPressed()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void StartButtonPressed()
    {
        
    }
}
