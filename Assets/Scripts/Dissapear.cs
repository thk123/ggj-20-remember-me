using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    public KeyCode AlphaUp;
    public KeyCode AlphaDown;
    private float Aalpha = 1.0f;
    private int counter = 0;
    public bool Tauched;
    Color OldColour;
    

    Color ChangeInAlpha;

    private float fadeValue;
    // Start is called before the first frame update
    void Start()
    {
        var material = GetComponent<Renderer>().material;
        fadeValue = 0.0f;

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<FirstPersonController>() != null)
        {
            makeVisible();
        }
    }

    private void makeVisible()
    {
        var Objects = GameObject.FindGameObjectsWithTag(gameObject.tag);
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].GetComponent<Dissapear>().Tauched = true;
        }
    }

    public void makeInvisible()
    {
        var Objects = GameObject.FindGameObjectsWithTag(gameObject.tag);
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].GetComponent<Dissapear>().Tauched = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        var material = GetComponent<Renderer>().material;
        if (Input.GetKeyDown(AlphaUp)) { Aalpha+=0.1f; material.color = new Color(1, 0, 0, Aalpha); }
        if (Input.GetKeyDown(AlphaDown)) { Aalpha -= 0.1f;  material.color = new Color(255, 255, 255, Aalpha); }
        if (Tauched == true)
        {
            if (counter > 100)
            {
                material.SetFloat("_Blend", 1.0f);
            }
            else
            {
                counter++;
                fadeValue += 0.01f;
                material.SetFloat("_Blend",fadeValue);
            }
        }
        else
        {
            if (counter > 0)
            {
                counter--;
                fadeValue -= 0.01f;
                material.SetFloat("_Blend",fadeValue);
            }
            else
            {
                material.SetFloat("_Blend", 0.0f);
            }
        }

    }
}