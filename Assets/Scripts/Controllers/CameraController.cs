using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Public objects
    public GameObject followObject;
    public float yOffset = 2.0f;

    // Components
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Position
        Vector3 position = new Vector3
        {
            x = followObject.transform.position.x,
            y = yOffset,
            z = transform.position.z
        };

        transform.position = position;

        // Direction
        transform.LookAt(followObject.transform);
    }
}
