using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRandomObjects : MonoBehaviour
{
    [MenuItem("Level Assist/Generate Items")]
    static void GenerateObjects()
    {
        List<String> tags = new List<string>();
        tags.Add("Tree");
        tags.Add("Box");
        tags.Add("Another");

        int numItems = 5;
        float minScale = 0.5f;
        float maxScale = 10f;
        const float minDistanceFromPlayer = 10.0f;
        const float maxDistanceFromPlayer = 100.0f;
        
        GameObject root = new GameObject();

        foreach (String tag in tags)
        {
            for (int i = 0; i < numItems; ++i)
            {
                GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Vector3 scale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, 10), Random.Range(minScale, 10));
                Vector2 offset = Random.insideUnitCircle * Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
                newObject.transform.SetPositionAndRotation(new Vector3(offset.x, scale.y *.5f, offset.y), Quaternion.identity);
                newObject.transform.localScale = scale;
                newObject.tag = tag;
                newObject.AddComponent<Dissapear>();
                newObject.transform.parent = root.transform;
            }
        }
    }
}
