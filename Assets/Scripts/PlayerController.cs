using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    FirstPersonController firstPersonControllerRef;
    CameraController cameraControllerRef;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonControllerRef = GetComponent<FirstPersonController>();
        cameraControllerRef = GetComponentInChildren<CameraController>();
    }

    public void playerDead()
    {
        firstPersonControllerRef.setPlayerDead();
        cameraControllerRef.SetPlayerDead();
    }
}
