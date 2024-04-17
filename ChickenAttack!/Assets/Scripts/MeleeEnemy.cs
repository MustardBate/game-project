using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyManager
{
    public float meleeDamage;

    new void Start()
    {
        base.Start();
    }

    private void Update()
    {
        //Conditions
        if (distance < rangeTilPursuit)
        {
            //Move the enemy towards Player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, walkingSpeed * Time.deltaTime);
        }
    }

}
