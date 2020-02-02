using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePassThroughData : MonoBehaviour
{
    public string playerName;
    //public Level
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
