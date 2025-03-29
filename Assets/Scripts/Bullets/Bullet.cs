using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 35f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifetime = 2f;

    private Rigidbody2D rb;

    // This method initializes the bullet's direction
    public void Initialize(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * bulletSpeed; // Set the bullet's velocity
        StartCoroutine(DestroyAfterLifetime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehaviour>().health -= damage;
        } else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().health -= damage;
            Debug.Log(collision.gameObject.GetComponent<PlayerController>().health);
        }
        
        Destroy(gameObject); // Destroy the bullet on collision
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}