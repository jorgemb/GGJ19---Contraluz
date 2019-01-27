using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    public void CollectWood()
    {
        //Destroy(GetComponent<Collider>());
        //Destroy(GetComponent<Rigidbody>());
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
