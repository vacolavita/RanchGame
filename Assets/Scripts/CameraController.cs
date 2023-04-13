using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraFollow;
    public Vector3 followTightness;
    public float rotTightness;
    public Vector3 cameraOffset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (cameraOffset).normalized;
        float dist = Mathf.Sqrt(Mathf.Pow(cameraOffset.x, 2) + Mathf.Pow(cameraOffset.z, 2));
        RaycastHit hit;



        if (Physics.Raycast(cameraFollow.position, dir.normalized, out hit, dist))
        {
            transform.SetPositionAndRotation(new Vector3(
Mathf.Lerp(transform.position.x, cameraFollow.position.x + cameraOffset.x / 2, followTightness.x * 3 * Time.deltaTime),
Mathf.Lerp(transform.position.y, cameraFollow.position.y + cameraOffset.y * 1.1f, followTightness.y * Time.deltaTime),
Mathf.Lerp(transform.position.z, cameraFollow.position.z - 2, followTightness.z * Time.deltaTime)
), transform.rotation);
        }
        else {
            transform.SetPositionAndRotation(new Vector3(
    Mathf.Lerp(transform.position.x, cameraFollow.position.x + cameraOffset.x, followTightness.x * Time.deltaTime),
    Mathf.Lerp(transform.position.y, cameraFollow.position.y + cameraOffset.y, followTightness.y * Time.deltaTime),
    Mathf.Lerp(transform.position.z, cameraFollow.position.z + cameraOffset.z, followTightness.z * Time.deltaTime)
    ), transform.rotation);
        }
        if (transform.position.z > cameraFollow.position.z - 1)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, cameraFollow.position.z - 1), transform.rotation);
        }

        Quaternion current = transform.rotation;

        transform.LookAt(cameraFollow);

        Quaternion newdir = transform.rotation;

        transform.SetPositionAndRotation(transform.position, Quaternion.Lerp(current, newdir, rotTightness * Time.deltaTime));

    }
}
