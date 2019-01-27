using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public void Collect()
    {
        if(!collected)
            Destroy(gameObject);
        collected = true;
    }

    public bool collected{ get; private set; }

    void Update()
    {
        collected = false;
    }
}
