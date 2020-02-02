using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingObjectAreaController : MonoBehaviour
{
    public GameObject ObjectToInstantiate;
    public int NumToInstantiate;
    List<GameObject> instantiatedObjects;

    public float MaxDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;    
        instantiatedObjects = new List<GameObject>();
        InstantiateAllObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MakeAllOthersInGroupVisible()
    {
        foreach(var obj in instantiatedObjects)
        {
            float randomWait = Random.Range(0, MaxDelay);
            yield return new WaitForSeconds(randomWait);
            obj.GetComponent<Dissapear>().SetVisibility(true);
        }
    }


    void InstantiateAllObjects()
    {
        for(int i=0; i < NumToInstantiate; i++)
        {
            Vector3 randomCoordinate;
            Vector3 origin = transform.position;

            Vector3 range = transform.localScale / 2.0f;
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                                Random.Range(-range.y, range.y),
                                                Random.Range(-range.z, range.z));
            randomCoordinate = origin + randomRange;

            var newObj = Instantiate(ObjectToInstantiate, randomCoordinate, Quaternion.identity);
            newObj.GetComponent<Dissapear>().setParentSpawner(this);
            instantiatedObjects.Add(newObj);
        }
    }

}
