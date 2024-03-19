using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Sensitivity")]
    public float sensX;
    public float sensY;

    
    public float lookSmooth;

    [Header("Settings")]
    public float leftRotAmount;
    public float rightRotAmount;

    public float returnFOV;
    public float zoomFOV;
    public float zoomSpeed;

    public Transform CameraHolder;
    [Header("Flashlight")]

    public Transform flashlight;
    public float flashMoveSpeed;
    public float flashMoveDev;

    [Header("Orientation")]
    public Transform roughRotation;
    public Transform orientation;
    
    public float xRotation;
    public float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (Input.GetKey(KeyCode.A))
        {
            roughRotation.rotation = Quaternion.Euler(roughRotation.rotation.x, roughRotation.rotation.y, roughRotation.rotation.z + leftRotAmount * 1000f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            roughRotation.rotation = Quaternion.Euler(roughRotation.rotation.x, roughRotation.rotation.y, roughRotation.rotation.z + rightRotAmount * 1000f);
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, returnFOV, zoomSpeed * Time.deltaTime);
        }

        roughRotation.rotation = Quaternion.Euler(xRotation, yRotation, roughRotation.rotation.z);

        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            
            transform.rotation = Quaternion.Lerp(transform.rotation, roughRotation.rotation, lookSmooth * Time.deltaTime);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            flashlight.rotation = Quaternion.Lerp(flashlight.rotation, transform.rotation, flashMoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftAlt))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, roughRotation.rotation, lookSmooth * Time.deltaTime);
        }
        // shoutout to Dave development or whatever his name is for the base of the character controller, freelook etc was added by me ;)
    }
}
