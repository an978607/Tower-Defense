using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon: MonoBehaviour
{
    public GameObject[] objects;
    public int currentCam;
    public GameObject PrepUI;
    public int runCheck;
    public int k;
    private void Start()
    {
        runCheck = 0;

        //main will always be the first camera in the array
        currentCam = 0;

        //count on array 
        k = 0;
    }
    private void Update()
    {
        //the preperation phase is over/ all weapons have been built. 
        if (PrepUI.activeSelf == false)
        {
            //only do once
            if (runCheck < 1)
            {
                objects = GameObject.FindGameObjectsWithTag("Camera");
                Debug.Log("Objects with Cameras found: " + objects.Length);
                currentCam = objects.Length - 2;
                runCheck++;
            }
        }


        //return to over head camera no matter where you are 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //enable main camera
            objects[0].GetComponent<Camera>().enabled = true;

            //disable other cams
            if (currentCam != 0)
            {
                objects[currentCam].GetComponent<Camera>().enabled = false;
            }

            //set current to current cam
            currentCam = 0;
        }

        //pan through cameras
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            k++;
            if (k >= objects.Length)
            {
                k = objects.Length - 1;
            }

            //activate the camera
            objects[k].GetComponent<Camera>().enabled = true;

            //deactivate previous cameras if its not the same
            if (k != currentCam)
            {
                objects[currentCam].GetComponent<Camera>().enabled = false;
            }

            //update currentCam
            currentCam = k;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            k--;
            if (k < 0)
            {
                k = 0;
            }

            //activate current cam
            objects[k].GetComponent<Camera>().enabled = true;

            if (k != currentCam)
            {
                objects[currentCam].GetComponent<Camera>().enabled = false;
            }

            currentCam = k;
        }
    }
}