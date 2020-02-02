using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryHoleController : MonoBehaviour
{
    public GameObject MemoryHole;
    float nextInstantiate;
    public float timeBetweenHoles = 2f;
    public int size = 5;
    public int timeToResizeHoles = 6;
    public float numIncrements = 10f;

    bool isShrinking = false;
    bool isUserInArea = false;

    public float VerticalFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        nextInstantiate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextInstantiate)
        {
            nextInstantiate = Time.time + timeBetweenHoles;
            isShrinking = !isShrinking;
            StartCoroutine(CreateMemoryHole(isShrinking));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isUserInArea = true;
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        isUserInArea = false;
    }

    IEnumerator CreateMemoryHole(bool isShrinking)
    {
        Vector3 randomCoordinate;
        Vector3 origin = transform.position;

        if (isUserInArea)
        {
            Vector2 offsetAroundPlayer = Random.insideUnitCircle * Random.Range(20, 50);
            randomCoordinate = new Vector3(origin.x + offsetAroundPlayer.x, 0.0f, origin.z + offsetAroundPlayer.y);
        }
        else
        {
            Vector3 range = transform.localScale / 2.0f;
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                              0.0f,
                                              Random.Range(-range.z, range.z));
            randomCoordinate = origin + randomRange;
        }

        var memoryHole = Instantiate(MemoryHole, randomCoordinate, Quaternion.identity);
        
        Vector3 startingScale;
        Vector3 targetScale;

        float timeIncrement = timeToResizeHoles / numIncrements;
        if (isShrinking)
        {
            startingScale = new Vector3(size, VerticalFactor * size, size);
            targetScale = new Vector3(0, 0, 0);
        }
        else
        {
            startingScale = new Vector3(0, 0, 0);
            targetScale = new Vector3(size, VerticalFactor * size, size);
        }

        memoryHole.transform.localScale = startingScale;
        for (int i=0; i< numIncrements; i++)
        {
            Vector3 scale = Vector3.Lerp(startingScale, targetScale, ((float) i) / ((float) numIncrements));
            memoryHole.transform.localScale = scale;
            yield return new WaitForSeconds(timeIncrement);

        }
        Destroy(memoryHole);
    }
}
