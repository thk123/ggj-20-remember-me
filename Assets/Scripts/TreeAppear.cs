using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAppear : MonoBehaviour
{
    public bool Visible = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {


        var material = GetComponent<Renderer>().material;
        var color = material.color;
        if (Visible == true) { material.color = new Color(0, 0, 1, 1); }
        if (Visible == false) { material.color = new Color(1, 1, 1, 1); }
    }

}
