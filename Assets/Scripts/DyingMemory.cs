using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingMemory : MonoBehaviour
{
    public float Lifetime = 10.0f;
    private float lifetimeRemaining;

    private Dissapear dissapear;
    // Start is called before the first frame update
    void Start()
    {
        dissapear = GetComponent<Dissapear>();
        lifetimeRemaining = Lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (dissapear.IsVisbile)
        {
            lifetimeRemaining -= Time.deltaTime;
            if (lifetimeRemaining <= 0.0f)
            {
                dissapear.makeInvisible();
                lifetimeRemaining = Lifetime;
            }
        }
    }
}
