using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryHoleController : MonoBehaviour
{
    public GameObject MemoryHole;
    float nextInstantiate;
    float timeBetweenHoles = 2f;
    bool isShrinking = false;
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

    IEnumerator CreateMemoryHole(bool isShrinking)
    {
        Vector3 origin = transform.position;
        Vector3 range = transform.localScale / 2.0f;
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          Random.Range(-range.z, range.z));
        Vector3 randomCoordinate = origin + randomRange;
        var memoryHole = Instantiate(MemoryHole, randomCoordinate, Quaternion.identity);

        float scaleIncrement;
        Vector3 startingScale;
        if (isShrinking)
        {
            startingScale = new Vector3(10,10,10);
            scaleIncrement = -.2f;
        }
        else
        {
            startingScale = new Vector3(0, 0, 0);
            scaleIncrement = .2f;

        }

        memoryHole.transform.localScale = startingScale;
        for (int i=0; i<20; i++)
        {
            Vector3 ls = memoryHole.transform.localScale;
            memoryHole.transform.localScale = new Vector3(ls.x + scaleIncrement, ls.y + scaleIncrement, ls.z+scaleIncrement);
            yield return new WaitForSeconds(.1f);

        }
        Destroy(memoryHole);
    }
}
