using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayerController : MonoBehaviour
{
    // Public data
    public float velocity = 120.0f;
    public KeyCode actionKey = KeyCode.Space;
    public KeyCode nextSceneKey = KeyCode.F10;

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

    bool canMove = true;
    private GameObject treeObject;

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
        // Check if movement is posible
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("NoMove"))
            canMove = false;
        else
            canMove = true;

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
        if(canMove)
            charController.SimpleMove(motion * Time.deltaTime);
        CheckCollisions();

        // Update animation
        if (motion.magnitude > 0 && canMove)
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

        float velocityEpsilon = 0.1f;
        if (charController.velocity.magnitude > velocityEpsilon && canMove)
            anim.SetBool("Running", true);
        else
            anim.SetBool("Running", false);

        // HUD
        UpdateHUD();
    }


    void UpdateHUD()
    {
        if(Input.GetKeyDown(nextSceneKey))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

                // Set animation
                anim.SetTrigger("Flint");
            } else if (treeObject)
            {
                anim.SetTrigger("CutWood");
                TreeController treeController = treeObject.GetComponent<TreeController>();
                treeController.CutTree();

                canMove = false;
            }
        }
    }

    private void ResetCollisions()
    {
        fireObject = null;
        treeObject = null;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.collider.tag)
        {
            case "Fire":
                fireObject = hit.gameObject;
                break;
            case "Wood":
                CollectableController collectable = hit.gameObject.GetComponent<CollectableController>();
                if(!collectable.collected)
                    firewood += 1;
                collectable.Collect();
                break;
            case "Tree":
                treeObject = hit.gameObject;
                break;
            default:
                break;
        }
    }
}
