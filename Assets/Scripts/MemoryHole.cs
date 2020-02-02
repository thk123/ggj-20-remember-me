using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryHole : MonoBehaviour
{
    PlayerController playerControllerRef;
    public ScreenFade AcessFadeScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        AcessFadeScript = FindObjectOfType<ScreenFade>();
        if (AcessFadeScript == null)
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
        print("your dead");
        playerControllerRef.playerDead();
    }
}
