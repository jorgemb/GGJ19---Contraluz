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
    Animator anim;
    Transform characterTransform;

    // Movement and collision
    GameObject fireObject = null;

    Vector3 currentLookAt;
    Vector3 targetLookAt;
    float lookAtLerp = 0.0f;

    void Start()
    {
        // Components
        charController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        foreach (var transform in GetComponentsInChildren<Transform>())
        {
            if(transform.name == "CHAR")
            {
                characterTransform = transform;
                break;
            }
        }

        // Transformation
        targetLookAt = characterTransform.forward;
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

        // Update animation
        if (motion.magnitude > 0)
        {
            Vector3 characterLookAt = new Vector3
            {
                x = -motion.x,
                y = 0.0f,
                z = -motion.z
            };

            if(targetLookAt == currentLookAt)
            {
                lookAtLerp += Time.deltaTime * 100.0f;
                Mathf.Clamp01(lookAtLerp);
            } else
            {
                targetLookAt = characterLookAt;
                currentLookAt = characterTransform.forward;
                lookAtLerp = 0.0f;
            }

            characterTransform.LookAt(targetLookAt);
        }

        if (charController.velocity.magnitude > 0)
            anim.SetBool("Running", true);
        else
            anim.SetBool("Running", false);

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
        CollectableController collectable = hit.gameObject.GetComponent<CollectableController>();

        switch (hit.collider.tag)
        {
            case "Fire":
                fireObject = hit.gameObject;
                break;
            case "Wood":
                if(!collectable.collected)
                    firewood += 1;
                collectable.Collect();
                break;
            default:
                break;
        }
    }
}
