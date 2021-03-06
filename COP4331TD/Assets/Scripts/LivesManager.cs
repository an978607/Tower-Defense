using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesDisplay;
    static public int currentLives;
    static public bool quit = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentLives"))
        {
            currentLives = PlayerPrefs.GetInt("CurrentLives");
        }
        else
        {
            currentLives = 5;
            PlayerPrefs.SetInt("CurrentLives", currentLives);
        }

        livesDisplay.text = currentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitLevel()
    {
        quit = true;
        updateLives();
    }

    private void updateLives()
    {
        if (quit != true)
            return;
        currentLives--;
        if (currentLives <= 0)
            currentLives = 5;
        PlayerPrefs.SetInt("CurrentLives", currentLives);
        quit = false;
    }


}

