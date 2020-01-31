using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearOncontact : MonoBehaviour
{
    public KeyCode AlphaUp;
    public KeyCode AlphaDown;
    public float Aalpha = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

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