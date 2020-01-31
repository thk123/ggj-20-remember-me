using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FirstPersonController : MonoBehaviour
{
    public float MaxSpeed;
    public float turnSpeed;

    public Camera face;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        
        var rot = new Vector3(0f, 0f, 0f);
        // rotates Camera Left
        if (Input.GetAxis("Mouse X") < 0)
        {
            rot.y -= 1;
        }
        // rotates Camera Left
        if (Input.GetAxis("Mouse X") > 0)
        {
            rot.y += 1;
        }
 
        // rotates Camera Up
        if (Input.GetAxis("Mouse Y") < 0)
        {
            rot.x += 1;
        }
        // rotates Camera Down
        if (Input.GetAxis("Mouse Y") > 0)
        {
            rot.x -= 1;
        }

        face.transform.Rotate(rot, turnSpeed * Time.deltaTime);
    }
}
