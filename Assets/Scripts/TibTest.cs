using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TibTest : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter =0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 1000)
        {
            var TreesObjects = GameObject.FindGameObjectsWithTag("Tree");
            for (int i = 0; i < 3; i++)
            {
                var material = TreesObjects[i].GetComponent<Renderer>().material;
                var color = material.color;
                material.color = new Color(1, 1, 1, 0);
                //for(int obj, obj <10, obj++) { TreesObjects[obj].GetComponent<MeshRenderer>().enabled = false; }//obj.GetComponent(TreeAppear).Visible = true; }
                //TreesObjects[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        if (counter > 4000) {
            var TreesObjects = GameObject.FindGameObjectsWithTag("Tree");
            for (int i = 0; i < 3; i++)
            {
                var material = TreesObjects[i].GetComponent<Renderer>().material;
                var color = material.color;
                material.color = new Color(5, 2, 5, 1);
                //for(int obj, obj <10, obj++) { TreesObjects[obj].GetComponent<MeshRenderer>().enabled = false; }//obj.GetComponent(TreeAppear).Visible = true; }
                //TreesObjects[i].GetComponent<MeshRenderer>().enabled = false;
            }
            counter = -100;
        }
        counter++;
    }
}
