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
    public float range;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < range)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenShot)
            {
                timer = 0;
                shoot();
            }
        }
    }

    private void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
