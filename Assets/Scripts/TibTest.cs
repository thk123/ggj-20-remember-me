using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TibTest : MonoBehaviour
{
    Color colorOld;
    // Start is called before the first frame update
    public int counter =0;
    void Start()
    {
        var TreesObjects = GameObject.FindGameObjectsWithTag("Tree");
        var material = TreesObjects[2].GetComponent<Renderer>().material;
        colorOld = material.color;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 1000)
        {
            var TreesObjects = GameObject.FindGameObjectsWithTag("Tree");
            for (int i = 0; i < TreesObjects.Length; i++)
            {
                var material = TreesObjects[i].GetComponent<Renderer>().material;
                var color = material.color;
                material.color = new Color(255, 255, 255, 0);
                //TreesObjects[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        if (counter > 2000) {
            var TreesObjects = GameObject.FindGameObjectsWithTag("Tree");
            for (int i = 0; i < TreesObjects.Length; i++)
            {
                var material = TreesObjects[i].GetComponent<Renderer>().material;
                var color = material.color;
                material.color = colorOld;
                //for(int obj, obj <10, obj++) { TreesObjects[obj].GetComponent<MeshRenderer>().enabled = false; }//obj.GetComponent(TreeAppear).Visible = true; }
                //TreesObjects[i].GetComponent<MeshRenderer>().enabled = false;
            }
            counter = -100;
        }
        counter++;
    }
}
