using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyManager
{
    public GameObject bullet;
    public Transform bulletPos;
    public Transform weapon;

    private float timer;
    public float timeBetweenShot;
    public float shootingRange;



    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();

        Vector3 displacement = weapon.position - player.transform.position;
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle + 180);
    }

    private void FixedUpdate()
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

                    CameraShake.Instance.ShakeCamera(3f, .1f);
                }
            }
        }
    }


    private void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
