using System;
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

    //private int MaxAmmo = 6;
    //private int CurrentAmmo;
    //public int reloadTime;
    //private bool isReloading = false;

    private int health;
    public int maxHealth;
    public HealthBar healthBar;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);  
        //CurrentAmmo = MaxAmmo;
    }

    //private void OnEnable()
    //{
    //    isReloading = false;
    //}

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
        //if (isReloading)
        //    return;

        //if(CurrentAmmo <= 0)
        //{
        //    StartCoroutine(Reload());
        //    return;
        //}

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
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


    private void Shoot()
    {
        //CurrentAmmo--;
        //Debug.Log("Current bullet:" + CurrentAmmo);
        if (Time.time > nextTimeShot)
        {
            nextTimeShot = Time.time + timeBetweenShot;
            Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        }
    }

    //IEnumerator Reload()
    //{
    //    isReloading = true;
    //    Debug.Log("Reloading");

    //    yield return new WaitForSeconds(reloadTime - .25f);
    //    yield return new WaitForSeconds(1f);

    //    CurrentAmmo = MaxAmmo;
    //    isReloading = false;
    //}
}

