using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Transform player;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Detect the target
        if (!player)
        {
            getPlayer();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void getPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDir = player.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Lerp(transform.localRotation, q, angle);
    }

}
