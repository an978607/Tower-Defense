using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreDisplay;
    public static int currentScore;
    public int currentScoreRef = currentScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            currentScore = PlayerPrefs.GetInt("CurrentScore");
        }
        else
        {
            currentScore = 0;
            PlayerPrefs.SetInt("CurrentScore", currentScore);
        }

         scoreDisplay.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddScore(int amount)
    {
        currentScore += amount;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
    }
    
    public int getScore(){
        return currentScore;
    }
}
