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
            transform.Translate(Vector3.forward * MaxSpeed, Space.Self);
        } 
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MaxSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MaxSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MaxSpeed, Space.Self);
        }
    }
}
