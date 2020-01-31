using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class FirstPersonController : MonoBehaviour
{
    public float MaxSpeed;
    public float turnSpeed;

    public Camera face;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState =CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(yClamped(transform.forward) * MaxSpeed, Space.World);
        } 
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(yClamped(transform.forward * -1) * MaxSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(yClamped(-1 * transform.right) * MaxSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(yClamped(transform.right) * MaxSpeed, Space.World);
        }
    }

    Vector3 yClamped(Vector3 inVector)
    {
        return new Vector3(inVector.x, 0.0f, inVector.z);
    }
}
