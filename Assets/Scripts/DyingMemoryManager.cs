using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DyingMemoryManager : MonoBehaviour
{
    private DyingMemory[] dyingMemories;

    // Start is called before the first frame update
    void Start()
    {
        dyingMemories = FindObjectsOfType<DyingMemory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dyingMemories.All(memory => memory.GetComponent<Dissapear>().Tauched))
        {
            Debug.Log("All memories visible!!");    
        }
        
    }
}
