using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BM_LevelSelect : MonoBehaviour
{
 
    public void levelOneButtonPressed()
    {
        SceneManager.LoadScene("Map01");
    }

    public void levelTwoButtonPressed()
    {
        SceneManager.LoadScene("Map02");
    }

    public void levelThreeButtonPressed()
    {
        SceneManager.LoadScene("Map03");
    }
}