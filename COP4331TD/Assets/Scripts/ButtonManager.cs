using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public void exitGame() {
        Application.Quit();
    }

    public void toggleCircleMovement() {
        GameObject demonstration = GameObject.Find("Demonstration");
        demonstration.GetComponent<DemonstrationEffect>().toggleMovement();
    }
}
