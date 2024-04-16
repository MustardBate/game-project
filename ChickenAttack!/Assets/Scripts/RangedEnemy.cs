using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject player;

    private float timer;
    public float timeBetweenShot;
    public float shootRange;
    public float walkingRange;
    public float walkingSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        //Conditions for enemy to pursuit player at certain range
        if (distance < walkingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, walkingSpeed * Time.deltaTime);
            //Conditions for enemy to shoot player at certain range
            if (distance < shootRange)
            {
                timer += Time.deltaTime;

                if (timer > timeBetweenShot)
                {
                    timer = 0;
                    shoot();
                }
            }
        }
    }

    private void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
