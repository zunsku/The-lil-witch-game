using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
    Vector3 newRotation = mainCamera.transform.eulerAngles;

    newRotation.x = 0;
    newRotation.z = 0;

    transform.eulerAngles = newRotation;
    }
}
