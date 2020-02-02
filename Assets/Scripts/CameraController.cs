using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    public float frameCounter = 20;
    Quaternion originalRotation;

    bool playerDead = false;

    public bool enabledDebug = true;
    private Color defaultClearColor;
    private Camera _camera;

    private bool cameraControlsActivated = true;

    void Update()
    {
        if (!playerDead && cameraControlsActivated)
        {
            moveCamera();
        }

        if (enabledDebug)
        {
            _camera.backgroundColor = Input.GetKey(KeyCode.V) ? Color.red : defaultClearColor;
        }
    }

    void moveCamera() {
        //Gets rotational input from the mouse
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;

        //Clamp the rotation average to be within a specific value range
        float clampedRotationY = ClampAngle(rotationY, minimumY, maximumY);
        float clampedRotationX = ClampAngle(rotationX, minimumX, maximumX);

        //Get the rotation you will be at next as a Quaternion
        Quaternion yQuaternion = Quaternion.AngleAxis(clampedRotationY, Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(clampedRotationX, Vector3.up);

        //Rotate
        transform.localRotation = originalRotation * xQuaternion * yQuaternion;
    }

    void Start()
    {
        _camera = GetComponent<Camera>();
        defaultClearColor = _camera.backgroundColor;
        originalRotation = transform.localRotation;
    }

    public void togglePlayerDead()
    {
        //playerDead = true;
        if (playerDead == false) { playerDead = true; }
        else { playerDead = false; }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }

            if (angle > 360F)
            {
                angle -= 360F;
            }
        }

        return Mathf.Clamp(angle, min, max);
    }

    public void setControlsActive(bool controlsActive)
    {
        this.cameraControlsActivated = controlsActive;
    }
}