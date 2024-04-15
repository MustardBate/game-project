using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Rigidbody2D rb;
    public float distanceBetween;

    private float distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Conditions
        if (distance < distanceBetween)
        {
            //Move the enemy towards Player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            //Rotating enemy towards player
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
