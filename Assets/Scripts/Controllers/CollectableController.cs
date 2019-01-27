using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    Rigidbody rb;
    float epsilon = 0.1f;

    public void Collect()
    {
        if(rb && rb.velocity.magnitude > epsilon)
        {
            return;
        }

        if(!collected)
            Destroy(gameObject);
        collected = true;
    }

    public bool collected{ get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        collected = false;
    }
}
