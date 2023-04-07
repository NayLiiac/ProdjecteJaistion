using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject CameraParent;
    public float speed = 5f;
    public float scrollSpeed = 5f;
    private bool isMouseOffScreen = false;
    Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         

        // Stop camera moves according to mouse position
        if (Input.GetMouseButton(0))
        {
            isMouseOffScreen = true;
        }

        // Reset camera moves according to mouse position
        if (Input.GetMouseButton(1))
        {
            isMouseOffScreen = false;
        }

        // Camera moves according to mouse position
        if (! isMouseOffScreen)
        {
            //Debug.Log("Mouse X : " + Input.mousePosition.x);
            //Debug.Log("Mouse Y : " + Input.mousePosition.z);

            float xInput = Input.GetAxis("Mouse X");
            float zInput = Input.GetAxis("Mouse Y");


            Vector3 dir = transform.forward * zInput + transform.right * xInput;
            transform.position += dir * speed;
        }

        // Allows to zoom
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            cam.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }

    }
}
