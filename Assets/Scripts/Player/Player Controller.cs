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
        MovementControls.action.canceled += MovementControlsWhenCanceled; 
    }

    void MovementControlsWhenPerformed(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void MovementControlsWhenCanceled(InputAction.CallbackContext context)
    {
        movement = Vector2.zero;
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
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}