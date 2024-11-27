using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject mainCamera;
    void Start()
    {
        
    }

    void Update()
    {
    Vector3 newRotation = mainCamera.transform.eulerAngles;

    newRotation.x = 0;
    newRotation.z = 0;

    transform.eulerAngles = newRotation;
    }
}
