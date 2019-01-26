using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    // Public data
    public float velocity = 2.0f;
    public bool enableJump = true;
    public float jumpVelocity = 2.0f;
    public KeyCode jumpKey = KeyCode.Space;

    // Components
    Rigidbody2D rb;

    // Movement
    int collisionLayer;
    bool canJump = false;

    void Start()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();

        // Layers
        collisionLayer = LayerMask.GetMask("Floor");
    }

    void Update()
    {
        // Calculate jump
        float verticalVelocity = 0.0f;
        if(canJump && Input.GetKey(jumpKey))
        {
            Debug.Log("JUMP!");
            verticalVelocity = jumpVelocity;
            canJump = false;
        }

        Vector2 motion = new Vector2(velocity * Input.GetAxis("Horizontal"), rb.velocity.y + verticalVelocity);
        rb.velocity = motion;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Jumping logic
        bool collisionWithFloor = ((1 << collision.gameObject.layer) & collisionLayer) > 0;
        if (collisionWithFloor && enableJump)
        {
            canJump = true;
        }
    }
}
