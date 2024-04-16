using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour
{
    private float health;
    public float fullHealth;

    public float rangeTilPursuit;
    public float walkingSpeed;
    protected float distance;

    public Rigidbody2D rb;
    public GameObject player;

    // Start is called before the first frame update
    protected void Start()
    {
        health = fullHealth;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
