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
    private Rigidbody _rigidBody;

    bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        Cursor.lockState =CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            movePlayer();
        }

    }

    public void setPlayerDead()
    {
        playerDead = true;
    }

    void movePlayer()
    {
        Cursor.visible = false;
        if (Input.GetKey(KeyCode.W))
        {
            _rigidBody.AddForce(yClamped(face.transform.forward) * MaxSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidBody.AddForce(yClamped(face.transform.forward) * MaxSpeed * -1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rigidBody.AddForce(yClamped(face.transform.right) * MaxSpeed * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidBody.AddForce(yClamped(face.transform.right) * MaxSpeed);
        }
    }

    Vector3 yClamped(Vector3 inVector)
    {
        return new Vector3(inVector.x, 0.0f, inVector.z);
    }
}
