using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Transform bulletsParent;
    [SerializeField] private float firingCooldown = 1f;
    
    private bool canFire = true;
    public bool isShooting = false;
    
    public int health = 20;
    
    
    // Start is called before the first frame update
    void Start()
    {
        bulletsParent = GameObject.FindGameObjectWithTag("BulletManager").transform;
        bulletSpawn = transform.GetChild(0).transform;
    }

    void Update()
    {
        if (isShooting && canFire)
        {
            SpawnBullet();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
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
