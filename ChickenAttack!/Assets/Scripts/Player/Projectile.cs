using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(1, 10)]
    public float bulletSpeed;

    [Range(1, 10)]
    public float lifeTime;

    public Rigidbody2D rb;

    public int damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyManager>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
