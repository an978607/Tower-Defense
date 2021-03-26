using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startLevel : MonoBehaviour {
    public Text lives, balance, score;
    public int startingLives;

    [HideInInspector]
    public int currentLives;
    // Start is called before the first frame update
    void Start() {
        currentLives = startingLives;
    }

    // Update is called once per frame
    void Update() {
        updateStats();
    }

    void updateStats() {
        lives.text = "♥" + currentLives;
        balance.text = "$" + CurrencyManager.currentBalance;
        score.text = "Score: " + ScoreManager.currentScore;
        
        /* To Do 
            Update lives and currency on level selection screen
        */
        
    }

    public void loseLives(int livesLost) {
        currentLives -= livesLost;
    }
}
