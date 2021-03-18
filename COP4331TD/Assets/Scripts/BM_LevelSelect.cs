using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BM_LevelSelect : MonoBehaviour
{
    public Button[] lockedLevels = new Button[5];
    int levelPassed;

    void Start()
    {
        if (PlayerPrefs.HasKey("LevelPassed"))
        {
            levelPassed = PlayerPrefs.GetInt("LevelPassed");
        }
        else
        {
            levelPassed = 0;
            PlayerPrefs.SetInt("LevelPassed", levelPassed);
        }

        for (int i = levelPassed + 1; i < lockedLevels.Length; i++)
            lockedLevels[i].interactable = false;
    }


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
    
    public void levelFourButtonPressed()
    {
        SceneManager.LoadScene("Map04");
    }
    
    public void levelFiveButtonPressed()
    {
        SceneManager.LoadScene("Map05");
    }
}