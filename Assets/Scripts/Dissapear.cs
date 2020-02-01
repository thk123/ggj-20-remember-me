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

    private Material[] materials;

    AppearingObjectAreaController appearingObjectAreaControllerRef;

    // Start is called before the first frame update
    void Start()
    {

        materials = GetComponent<Renderer>().materials;
        fadeValue = 0.0f;
    }

    public void setParentSpawner(AppearingObjectAreaController appearingObjectAreaControllerNew)
    {
        appearingObjectAreaControllerRef = appearingObjectAreaControllerNew;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<FirstPersonController>() != null)
        {
            SetVisibility(true);
            StartCoroutine(appearingObjectAreaControllerRef.MakeAllOthersInGroupVisible());
        }
    }

    public void SetVisibility( bool newVisibility)
    {
        Tauched = newVisibility;
    }

    // Update is called once per frame
    void Update()
    {
        if (Tauched == true)
        {
            if (counter > 100)
            {
                setBlendLevel(1.0f);
            }
            else
            {
                counter++;
                fadeValue += 0.01f;
                setBlendLevel(fadeValue);
            }
        }
        else
        {
            if (counter > 0)
            {
                counter--;
                fadeValue -= 0.01f;
                setBlendLevel(fadeValue);
            }
            else
            {
                setBlendLevel(0.0f);
            }
        }

    }

    void setBlendLevel(float level)
    {
        foreach (Material material in materials)
        {
            material.SetFloat("_Blend", level);
        }
    }
}