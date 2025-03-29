using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;

    [SerializeField] private InputActionReference MovementControls;

    private Vector2 movement;

    private void OnEnable()
    {
        MovementControls.action.Enable();
    }

    private void Start()
    {
        MovementControls.action.performed += MovementControlsWhenPerformed;
        MovementControls.action.canceled += MovementControlsWhenCanceled; // Handle when movement stops
    }

    void MovementControlsWhenPerformed(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void MovementControlsWhenCanceled(InputAction.CallbackContext context)
    {
        movement = Vector2.zero; // Stop movement when controls are canceled
    }

    void Update()
    {
        // Rotate the player to face the movement direction
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg; // Calculate angle in degrees
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Rotate the player
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * speed; // Normalize movement to maintain consistent speed
    }
}