using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    // Public data
    public float velocity = 120.0f;
    public KeyCode actionKey = KeyCode.Space;

    // Inventory
    int axe = 0;
    int firewood = 0;
    int flint = 0;
    int food = 0;

    // Components
    CharacterController charController;

    // Movement
    int collisionLayer;

    void Start()
    {
        // Components
        charController = GetComponent<CharacterController>();

        // Layers
        collisionLayer = LayerMask.GetMask("Floor");
    }

    void Update()
    {
        // Calculate motion
        Vector2 xz_movement = new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };
        xz_movement = xz_movement.normalized * velocity;

        Vector3 motion = new Vector3
        {
            x = xz_movement.x,
            y = 0.0f,
            z = xz_movement.y
        };

        charController.SimpleMove(motion * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
