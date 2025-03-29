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

    void OnDisable()
    {
        ShootingControls.action.Disable();
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
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation, bulletsParent.transform);
        
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        Vector2 shootDirection = bulletSpawn.right;
        bulletScript.Initialize(shootDirection);
    
        StartCoroutine(FireCooldown());
    }

    private IEnumerator FireCooldown()
    {
        canFire = false; 
        yield return new WaitForSeconds(firingCooldown); 
        canFire = true; 
    }
}