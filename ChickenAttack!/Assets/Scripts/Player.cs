using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;

    public Transform weapon;    
    public float offset;

    public Transform shotPoint;
    public GameObject projectile;

    public float timeBetweenShot;
    float nextTimeShot;

    private float health;
    public float maxHealth;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Setting animation for movement
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Gun rotation
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle + offset);

        //Shooting
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextTimeShot)
            {
                nextTimeShot = Time.time + timeBetweenShot;
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            }
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }   
}

