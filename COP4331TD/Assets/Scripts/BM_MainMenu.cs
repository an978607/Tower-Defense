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
        volumeSlider.gameObject.SetActive(false);
    }

    public void playButtonPressed() {
        SceneManager.LoadScene("Map00a");
    }

    public void settingsButtonPressed() {
        volumeSlider.gameObject.SetActive(!volumeSlider.gameObject.activeSelf);
    }

    public void changeMusicVolume() {
        music.volume = volumeSlider.value;
    }

}
