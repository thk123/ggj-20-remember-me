using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DyingMemoryManager : MonoBehaviour
{
    private DyingMemory[] dyingMemories;

    public Dialogue ThingToEnable; 

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
            foreach (var dyingMemory in dyingMemories)
            {
                dyingMemory.enabled = false;
            }

            if (ThingToEnable != null)
            {
                ThingToEnable.DisableGibberish();
            }
            else
            {
                Debug.LogWarning("All dying memories complete - but nothing happens!");
            }
        }
        
    }
}
