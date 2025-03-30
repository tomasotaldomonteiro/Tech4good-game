using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public Animator animator;
    public float health = 30f;

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
       
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); 
        }
        
        if (health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * speed;
        animator.SetFloat("Speed", movement.magnitude);
    }
    
    private IEnumerator Death()
    {
        Destroy(GameObject.Find("AllyManager"));
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}