using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAppear : MonoBehaviour
{
    public bool Visible = false;
    Color ChangeInAlpha;
    Color Oldcolor;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        var material = GetComponent<Renderer>().material;
        ChangeInAlpha = material.color;
        ChangeInAlpha.a = 0.0f;
        Oldcolor = material.color;
    }
    // Update is called once per frame
    void Update()
    {

        var material = GetComponent<Renderer>().material;


        if (Visible == true)
        {
            if (counter > 100)
            {
                material.color = Oldcolor;
            }
            else
            {
                counter++;
                ChangeInAlpha.a+=0.01f;
                material.color = ChangeInAlpha;
            }
        }
    }

}
