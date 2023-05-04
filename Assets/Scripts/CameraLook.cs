using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject[] animalList;
    public GameObject cameraContainer;
    public GameObject player;
    public Camera cam;
    public int[] scores;

    private void Start()
    {
        scores = new int[animalList.Length];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scores[0] + ", " + scores[1] + ", " + scores[2]);
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
        scor = (Vector3.Dot(rot, toOther) + 1) * 50;
        scor *= 1.01f;
        scor = Mathf.Clamp(scor, 0, 100);
        return (int)scor;
    }

    bool inCamera(GameObject obj) {
        Plane[] cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        Bounds bounds = obj.GetComponent<Collider>().bounds;
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds)) {
            Vector3 direction = cameraContainer.transform.position - obj.transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(obj.transform.position, direction.normalized, out hit, 100))
            {
                if (hit.collider == player.GetComponent<Collider>())
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void takePicture() {
        int scor = 0;
        int scortemp = 0;
        int index = -1;
        for (int i = 0; i <= animalList.Length-1; i++)
        {
            if (inCamera(animalList[i])) {
                scortemp = getDistance(animalList[i]) + getCentered(animalList[i]) + getDirection(animalList[i]);
                if (scortemp > scor) {
                    scor = scortemp;
                    index = i;
                }
            }
            scortemp = 0;
        }
        if (index != -1 && scor > scores[index]) {
            scores[index] = scor;
        }
    }
}
