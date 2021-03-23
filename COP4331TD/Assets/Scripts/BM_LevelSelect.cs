using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BM_LevelSelect : MonoBehaviour
{
    public Button[] lockedLevels = new Button[5];
    int levelPassed;
    
    int currLevel; // player's current level
    
    void Start()
    {
    
        // Get how many levels have been passed
        if (PlayerPrefs.HasKey("LevelPassed"))
        {
            levelPassed = PlayerPrefs.GetInt("LevelPassed");
        }
        else
        {
            levelPassed = 0;
            PlayerPrefs.SetInt("LevelPassed", levelPassed);
        }

        // Beat the game, display to the user OR let user choose next
        if(levelPassed >= 5){
            Debug.Log("Game won!");
        } 
        else{
            // locks the other levels from being clickable
            for (int i = levelPassed + 1; i < lockedLevels.Length; i++)
                lockedLevels[i].interactable = false;
        }
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