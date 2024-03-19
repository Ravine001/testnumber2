using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    public Transform playerCam;
    public Transform camPos;
    public float returnSpeed;

    void Update()
    {
        playerCam.position = Vector3.Lerp(playerCam.position, camPos.position, returnSpeed * Time.deltaTime);
    }
}
