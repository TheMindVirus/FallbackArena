using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //private float speed;
    private float sensitivity;
    private Vector3 facing;

    void Start()
    {
        //speed = 0.1f;
        sensitivity = 1.5f;
    }

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + (Input.GetAxis("Mouse Y") * sensitivity * -1.0f),
                                                     transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * sensitivity),
                                                     transform.localEulerAngles.z);
        }
    }
}