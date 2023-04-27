using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    // public GameObject camera1;
    // public GameObject camera2;
    
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;
    
    bool oneTime = false;
    bool oneTimeAgain = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkOrient();

        /* if (Input.deviceOrientation==DeviceOrientation.Portrait)
        {
            ThirdCam.SetActive (false);
            FirstCam.SetActive (true);
            Debug.Log("This is portrait mode.");
        }
        else{
            ThirdCam.SetActive (true);
            FirstCam.SetActive (false);
            Debug.Log("This is landscape mode.");
        } */

        /* if (Input.GetKeyDown("c"))
        {
            if (CamMode == 1){
                CamMode = 0;
            }
            else{
                CamMode += 1;
            }
            StartCoroutine(CameraChange());
        } */

        /* For testing purposes. Press '1' or '2' switches between two cameras
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            camera1.SetActive(true);
            camera2.SetActive(false);
        }    
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Screen.orientation = ScreenOrientation.Portrait;
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        */    
    }

    /* IEnumerator CameraChange()
        {
            yield return new WaitForSeconds (0.01f);
            if (CamMode == 0){
                ThirdCam.SetActive (true);
                FirstCam.SetActive (false);
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                Debug.Log("The screen is landscape.");
            }
            if (CamMode == 1){
                ThirdCam.SetActive (false);
                FirstCam.SetActive (true);
                Screen.orientation = ScreenOrientation.Portrait;
                Debug.Log("The screen is portrait.");
            }
        }*/
    
    void checkOrient()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown){
            ThirdCam.SetActive (false);
            FirstCam.SetActive (true);
            if(!oneTimeAgain){
                Debug.Log("The game is currently in portrait mode.");
                oneTimeAgain = true;
            }
            
        }
        else{
            ThirdCam.SetActive (true);
            FirstCam.SetActive (false);
            if(!oneTime){
                Debug.Log("The game is currently in landscape mode.");
                oneTime = true;
            }
        }
    }
}
