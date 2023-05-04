using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject[] animalList;
    public GameObject cameraContainer;
    public Camera cam;
    private int[] scores; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(getDistance(animalList[0]) +
            ", " +
            getCentered(animalList[0]) +
            ", " +
            getDirection(animalList[0])
            );
        
    }

    int getDistance(GameObject obj) {
        float scor = 0;
        scor = Mathf.Clamp(140 - Vector3.Distance(obj.transform.position, cameraContainer.transform.position) * 3, 0, 100);
        return (int)scor;
    }

    int getCentered(GameObject obj) {
        float scor = 0;
        Vector3 rot = cameraContainer.transform.TransformDirection(Vector3.forward);
        Vector3 toOther = obj.transform.position - cameraContainer.transform.position;
        toOther.Normalize();
        scor = Vector3.Dot(rot, toOther) * 100;
        scor -= 90;
        scor *= 10.02f;
        scor = Mathf.Clamp(scor, 0, 100);
        return (int)scor;
    }

    int getDirection(GameObject obj) {
        float scor = 0;
        Vector3 rot = obj.transform.TransformDirection(Vector3.forward);
        Vector3 toOther = new Vector3(cameraContainer.transform.position.x, obj.transform.position.y, cameraContainer.transform.position.z) - obj.transform.position;
        toOther.Normalize();
        scor = Vector3.Dot(rot, toOther) * 100;
        scor *= 1.02f;
        scor = Mathf.Clamp(scor, 0, 100);
        return (int)scor;
    }
}