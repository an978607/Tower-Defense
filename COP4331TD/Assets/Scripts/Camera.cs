using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject overheadCam;
    public GameObject towerCam;
    private void Update()
    {
        //Space takes you back to the over head view
        if(Input.GetKeyDown(KeyCode.Space))
        {
            overheadCam.SetActive(true);
            towerCam.SetActive(false);
        }

        //arrow keys move you up and down a list of cameras
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            overheadCam.SetActive(false);
            towerCam.SetActive(true);
        }
    }
}
