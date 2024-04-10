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

    public int health;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
    }
}
