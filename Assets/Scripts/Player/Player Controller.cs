using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    
    [SerializeField] private InputActionReference PlayerControls;
    
    private Vector2 movement;

    private void OnEnable()
    {
        PlayerControls.action.Enable();
    }

    // private void OnDisable()
    // {
    //     PlayerControls.Disable();
    // }

    private void Start()
    {
        PlayerControls.action.performed += PlayerControlsWhenPerformed;
    }

    void PlayerControlsWhenPerformed(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
      // float moveX = Input.GetAxis("Horizontal");
      // float moveY = Input.GetAxis("Vertical");
      // movement = new Vector2(moveX, moveY).normalized;
      //
      // movement = PlayerControls.ReadValue<Vector2>();
      
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    
    
}
