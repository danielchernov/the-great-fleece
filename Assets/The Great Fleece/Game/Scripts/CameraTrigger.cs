using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    Transform CameraAngle;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Camera.main.transform.position = CameraAngle.position;
            Camera.main.transform.rotation = CameraAngle.rotation;
        }
    }
}
