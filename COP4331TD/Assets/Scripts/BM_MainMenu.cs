using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BM_MainMenu : MonoBehaviour {
    //public GameObject playButton, settingsButton;
    public Slider volumeSlider;
    public AudioSource music;


    //private bool settingsOpen = false;
    void Start() {
        music.volume = 0.5f;
    }

    public void playButtonPressed() {
        SceneManager.LoadScene("Map00a");
    }

    public void settingsButtonPressed() {
        // TODO
        // create new GUI
    }

    public void changeMusicVolume() {
        music.volume = volumeSlider.value;
    }

}
