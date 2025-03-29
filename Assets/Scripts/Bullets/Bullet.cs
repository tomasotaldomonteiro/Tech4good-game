using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 35f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private Transform player;
    private Rigidbody2D rb;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = bulletSpeed * player.right;
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyAfterLifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.name);
        }
        Debug.Log(Time.realtimeSinceStartup);
        Destroy(gameObject);
    }
    
    void MoveBullet()
    {
        Vector2 newPosition = transform.position + direction * Time.deltaTime;
        rb.MovePosition(newPosition);
        
        // rb.velocity = new Vector2(bulletSpeed * player.right, rb.velocity.y) * Time.deltaTime;
    }

    private IEnumerator DestroyAfterLifeTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
