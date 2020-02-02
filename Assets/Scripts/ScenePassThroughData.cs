using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenePassThroughData : MonoBehaviour
{
    public string playerName;
    public int levelNum;
    public bool levelDefault;

    void Awake()
    {
        if (!levelDefault)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static ScenePassThroughData GetData()
    {
        var data = GameObject.FindObjectsOfType<ScenePassThroughData>();
        return data.Length == 1 ? data[0] : data.First(foundData => !foundData.levelDefault);
    }
}
