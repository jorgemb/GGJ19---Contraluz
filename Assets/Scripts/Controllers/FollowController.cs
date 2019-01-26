using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FollowController : MonoBehaviour
{
    // Public fields
    /* Follow object */
    public Transform followTarget;

    /* Conststraints */
    [Header("Constraints")]
    public bool moveX = true;
    public bool moveY = true;
    public bool moveZ = true;

    /* Offsets */
    [Header("Offsets")]
    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;

    void Update()
    {
        if (followTarget)
        {
            Vector3 newPosition = transform.position;
            if (moveX)
                newPosition.x = followTarget.position.x + xOffset;

            if (moveY)
                newPosition.y = followTarget.position.y + yOffset;

            if (moveZ)
                newPosition.z = followTarget.position.z + yOffset;

            transform.position = newPosition;
        }
    }
}
