using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MemoryHole : MonoBehaviour
{
    PlayerController playerControllerRef;
    ScreenFade accessFadeScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        accessFadeScript = FindObjectOfType<ScreenFade>();
        if (accessFadeScript == null)
        {
            Debug.LogWarning("Could not fnid screen fade");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter(Collision collision)
    {
        accessFadeScript.loadCurrentLevelBecauseDead();
        print("your dead");
        playerControllerRef.playerDead();
    }
}
