using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private GameObject enemy;

    private EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        enemy = transform.parent.gameObject;
        enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyBehaviour.isShooting = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)  
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        Vector3 direction = collision.transform.position - enemy.transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        enemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyBehaviour.isShooting = false;
        }
    }
}
