using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    public KeyCode AlphaUp;
    public KeyCode AlphaDown;
    public float Aalpha = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        var material = GetComponent<Renderer>().material;
        material.color = new Color(1, 1, 1, 1);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colldied");
        if(other.gameObject.GetComponent<FirstPersonController>() != null)
        {
            makeVisible();
        }
    }

    private void makeVisible()
    {
        var material = GetComponent<Renderer>().material;
        material.color = new Color(1.0f, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        var material = GetComponent<Renderer>().material;
        var color = material.color;
        if (Input.GetKeyDown(AlphaUp)) { material.color = new Color(1, 0, 0, 1); }
        if (Input.GetKeyDown(AlphaDown)) { material.color = new Color(255, 255, 255, 1); }
    }
}