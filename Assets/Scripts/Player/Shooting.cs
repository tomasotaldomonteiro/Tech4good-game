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
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation, bulletsParent.transform);
    
        // Get the Bullet component and initialize it with the shooting direction
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        Vector2 shootDirection = bulletSpawn.right; // Assuming the bulletSpawn's right direction is the shooting direction
        bulletScript.Initialize(shootDirection);
    
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