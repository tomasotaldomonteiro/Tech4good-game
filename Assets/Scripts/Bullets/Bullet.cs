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
            Debug.Log($"Hit: {collision.gameObject.name}");
            // Here you can apply damage to the enemy if needed
            // Example: collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        } else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Hit: {collision.gameObject.name}");
        }
        
        Destroy(gameObject); // Destroy the bullet on collision
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}