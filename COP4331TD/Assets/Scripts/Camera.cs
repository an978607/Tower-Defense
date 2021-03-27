using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject mainC;
    public GameObject towerC;
    public GameObject attackUI;
    Camera mainCamera;
    Camera towerCamera;
    AudioListener bur;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = mainC.GetComponent("Camera") as Camera;
        towerCamera = towerC.GetComponent("Camera") as Camera;
        bur = mainC.GetComponent<AudioListener>();

        mainCamera.enabled = true;
        towerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mainCamera.enabled = !mainCamera.enabled;
            towerCamera.enabled = !towerCamera.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainCamera.enabled = true;
            towerCamera.enabled = false;
        }

    }
}
