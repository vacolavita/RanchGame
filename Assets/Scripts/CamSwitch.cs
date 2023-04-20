using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For testing purposes. Press '1' or '2' switches between two cameras
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
    }
}
