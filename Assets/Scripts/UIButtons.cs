using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    /* Testing switching cameras and change of orientation. 
    The "camera" button changes to a different camera and switches to portrait mode. 
    Menu goes back to landscape at Cam 1. */
    public void OnCameraButtonClick()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        camera1.SetActive(false);
        camera2.SetActive(true);
        Debug.Log("this is working");
    }

    public void OnMenuButtonClick()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        camera1.SetActive(true);
        camera2.SetActive(false);
        Debug.Log("this is working");
    } 
}
