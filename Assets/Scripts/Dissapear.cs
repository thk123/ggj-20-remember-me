using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    public KeyCode AlphaUp;
    public KeyCode AlphaDown;
    public float Aalpha = 1.0f;
    Color OldColour;

    public bool IsVisbile
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        var material = GetComponent<Renderer>().material;
        OldColour = material.color;
        IsVisbile = false;
        // material.color = new Color(45, 45, 0, 1);
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
        IsVisbile = true;
        var TreesObjects = GameObject.FindGameObjectsWithTag(gameObject.tag);
        for (int i = 0; i < TreesObjects.Length; i++)
        {
            TreesObjects[i].GetComponent<Dissapear>().IsVisbile = true;
            var material = TreesObjects[i].GetComponent<Renderer>().material;
            var color = material.color;
            //material.color = OldColour;
            material.color = Color.red;
            //for(int obj, obj <10, obj++) { TreesObjects[obj].GetComponent<MeshRenderer>().enabled = false; }//obj.GetComponent(TreeAppear).Visible = true; }
            //TreesObjects[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void makeInvisible()
    {
        IsVisbile = false;
        var TreesObjects = GameObject.FindGameObjectsWithTag(gameObject.tag);
        for (int i = 0; i < TreesObjects.Length; i++)
        {
            var material = TreesObjects[i].GetComponent<Renderer>().material;
            var color = material.color;
            //material.color = OldColour;
            material.color = Color.white;
            //for(int obj, obj <10, obj++) { TreesObjects[obj].GetComponent<MeshRenderer>().enabled = false; }//obj.GetComponent(TreeAppear).Visible = true; }
            //TreesObjects[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var material = GetComponent<Renderer>().material;
        var color = material.color;
        if (Input.GetKeyDown(AlphaUp)) { Aalpha++; material.color = new Color(1, 0, 0, Aalpha); }
        if (Input.GetKeyDown(AlphaDown)) { Aalpha--;  material.color = new Color(255, 255, 255, Aalpha); }
    }
}