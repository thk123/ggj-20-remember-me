using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryHole : MonoBehaviour
{
    PlayerController playerControllerRef;
    public GameObject AcessFadeScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
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
