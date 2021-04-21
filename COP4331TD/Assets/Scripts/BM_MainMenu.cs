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
        PlayerPrefs.SetInt("LevelPassed", 0);
        PlayerPrefs.SetInt("CurrentBalance", 200);
        PlayerPrefs.SetInt("CurrentLives", 5);
        PlayerPrefs.SetInt("CurrentScore", 0);
        music.volume = 0.5f;
        volumeSlider.gameObject.SetActive(false);
    }

    public void playButtonPressed() {
        SceneManager.LoadScene("LevelSelection");
    }

    public void settingsButtonPressed() {
        volumeSlider.gameObject.SetActive(!volumeSlider.gameObject.activeSelf);
    }

    public void quitButtonPressed()
    {
        Application.Quit();
    }

    public void changeMusicVolume() {
        music.volume = volumeSlider.value;
    }

}
