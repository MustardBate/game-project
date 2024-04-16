using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyManager
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    public float timeBetweenShot;
    public float shootingRange;


    new void Start()
    {
        base.Start();
    }

    private void Update()
    {
        //Conditions for enemy to pursuit player at certain range
        if (distance < rangeTilPursuit)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, walkingSpeed * Time.deltaTime);
            //Conditions for enemy to shoot player at certain range
            if (distance <= shootingRange)
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
