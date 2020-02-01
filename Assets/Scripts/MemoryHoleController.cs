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
        print("entered zone");
        isUserInArea = true;
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        print("exit zone");
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

        float scaleIncrement;
        Vector3 startingScale;


        float timeIncrement = timeToResizeHoles / numIncrements;
        scaleIncrement = size / numIncrements;
        if (isShrinking)
        {
            startingScale = new Vector3(size, 0.01f, size);
            scaleIncrement = -scaleIncrement;
        }
        else
        {
            startingScale = new Vector3(0, 0.01f, 0);
        }

        memoryHole.transform.localScale = startingScale;
        for (int i=0; i< numIncrements; i++)
        {
            Vector3 ls = memoryHole.transform.localScale;
            memoryHole.transform.localScale = new Vector3(ls.x + scaleIncrement, 0.01f, ls.z+scaleIncrement);
            yield return new WaitForSeconds(timeIncrement);

        }
        Destroy(memoryHole);
    }
}
