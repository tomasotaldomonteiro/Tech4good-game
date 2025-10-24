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
    
    public float health = 20;
    
    
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
            StopCoroutine(FireCooldown());
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
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
