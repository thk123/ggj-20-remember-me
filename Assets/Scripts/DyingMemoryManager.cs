using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DyingMemoryManager : MonoBehaviour
{
    private DyingMemory[] dyingMemories;

    public Dialogue ThingToEnable;

    public AudioClip[] successChimes;

    // Start is called before the first frame update
    void Start()
    {
        dyingMemories = FindObjectsOfType<DyingMemory>();
        StartCoroutine(chimes());
    }

    IEnumerator chimes()
    {
        int chimesPlayed = 0;
        int totalDyingMemories = getTotalDyingMemories();
        if (totalDyingMemories > successChimes.Length)
        {
            Debug.LogWarning("Insufficent chimes");
        }
        while (getDyingMemoriesComplete() < totalDyingMemories)
        {
            yield return new WaitUntil(() => getDyingMemoriesComplete() != chimesPlayed);
            Debug.Log("chime! " + getTotalDyingMemories());
            GetComponent<AudioSource>().PlayOneShot(successChimes[successChimes.Length - totalDyingMemories + chimesPlayed]);
            ++chimesPlayed;
        }
        
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
    int getDyingMemoriesComplete()
    {
        return dyingMemories.Count(memory => memory.GetComponent<Dissapear>().Tauched);
    }
    
    int getTotalDyingMemories()
    {
        return dyingMemories.Length;
    }
}
