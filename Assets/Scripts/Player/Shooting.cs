using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float firingCooldown = 0.2f;
    [SerializeField] private GameObject bulletsParent;
    private bool canFire = true;

    [SerializeField] private InputActionReference ShootingControls;

    void OnEnable()
    {
        ShootingControls.action.Enable();
    }

    void Start()
    {
        ShootingControls.action.performed += WhenShootingIsPerformed;
        bulletSpawn = transform.GetChild(0).transform;
    }

    void WhenShootingIsPerformed(InputAction.CallbackContext callbackContext)
    {
        if (canFire)
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        // Instantiate the bullet
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation, bulletsParent.transform);
        
        // Start the cooldown coroutine
        StartCoroutine(FireCooldown());
    }

    private IEnumerator FireCooldown()
    {
        canFire = false; // Prevent firing
        yield return new WaitForSeconds(firingCooldown); // Wait for the cooldown duration
        canFire = true; // Allow firing again
    }
}