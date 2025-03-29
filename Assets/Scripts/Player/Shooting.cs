using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float firingCooldown = 0.1f;
    private bool canFire = true;

    void Start()
    {
        bulletSpawn = transform.GetChild(1).transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        canFire = false; 
        StartCoroutine(FireCooldown()); 
    }

    private IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(firingCooldown); 
        canFire = true; 
    }
}