using System;
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

    // Movement and collision
    GameObject fireObject = null;

    void Start()
    {
        // Components
        charController = GetComponent<CharacterController>();
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

        ResetCollisions();
        charController.SimpleMove(motion * Time.deltaTime);
        CheckCollisions();


        // HUD
        UpdateHUD();
    }

    void UpdateHUD()
    {

    }

    private void CheckCollisions()
    {
        if (Input.GetKeyDown(actionKey))
        {
            if (fireObject != null && firewood > 0)
            {
                // Add firewood to the fire
                FireController fireController = fireObject.GetComponent<FireController>();
                fireController.AddIntensity();
                firewood -= 1;
            }
        }
    }

    private void ResetCollisions()
    {
        fireObject = null;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.collider.tag)
        {
            case "Fire":
                fireObject = hit.gameObject;
                break;
            case "Wood":
                firewood += 1;
                hit.gameObject.GetComponent<WoodController>().CollectWood();
                break;
            default:
                break;
        }
    }
}
