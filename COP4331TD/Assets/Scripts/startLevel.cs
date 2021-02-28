using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startLevel : MonoBehaviour {
    public Text lives, balance;
    public int startingLives, startingBalance;

    [HideInInspector]
    public int currentLives, currentBalance;
    // Start is called before the first frame update
    void Start() {
        currentLives = startingLives;
        currentBalance = startingBalance;
    }

    // Update is called once per frame
    void Update() {
        updateStats();
    }

    void updateStats() {
        lives.text = "♥" + currentLives;
        balance.text = "$" + currentBalance;
    }

    public void loseLives(int livesLost) {
        currentLives -= livesLost;
    }
}
