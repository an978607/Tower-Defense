using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesDisplay;
    static public int currentLives;
    static public bool quit = false;
    public int currentLivesRef = currentLives;
    float lifeReplenishTime = 60f;
    int maxLives = 5;
    double timerForLife = 0;

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
        if (currentLives < maxLives)
        {
            timerForLife += Time.deltaTime;
            if (timerForLife > lifeReplenishTime)
            {
                UpdateLives(timerForLife);
                livesDisplay.text = currentLives.ToString();
            }
        }
    }


    void UpdateLives(double timerToAdd)
    {
        if (currentLives < maxLives)
        {
            timerForLife = (float)timerToAdd % lifeReplenishTime;
             currentLives++;
             PlayerPrefs.SetInt("CurrentLives", currentLives);

            if (currentLives > maxLives)
            {
                currentLives = maxLives;
                timerForLife = 0;
            }
        }
        PlayerPrefs.SetString("LifeUpdateTime", System.DateTime.Now.ToString());
    }

    public void quitLevel()
    {
        quit = true;
        subLife();
    }

    private void subLife()
    {
        if (quit != true)
            return;
        currentLives--;
        PlayerPrefs.SetInt("CurrentLives", currentLives);
        quit = false;
    }


}

