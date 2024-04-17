using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour
{
    private int health;
    public int fullHealth;

    public float rangeTilPursuit;
    public float walkingSpeed;
    protected float distance;

    public Rigidbody2D rb;
    public GameObject player;

    public HealthBar healthBar;

    // Start is called before the first frame update
    protected void Start()
    {
        health = fullHealth;
        healthBar.setMaxHealth(fullHealth);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.setHealth(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
