using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BM_Map00a : MonoBehaviour {

    public Slider fontSlider, speedSlider, radiusSlider;
    public GameObject demonstration;

    public void exitGame() {
        Application.Quit();
    }

    public void toggleCircleMovement() {
        demonstration.GetComponent<DemonstrationEffect>().toggleMovement();
    }

    public void changeFontSize() {
        demonstration.GetComponent<DemonstrationEffect>().changeFontSize((int) fontSlider.value);
    }

    public void changeSpeed() {
        demonstration.GetComponent<DemonstrationEffect>().changeSpeed(speedSlider.value);
    }

    public void changeRadius() {
        demonstration.GetComponent<DemonstrationEffect>().changeRadius(radiusSlider.value);
    }
}
