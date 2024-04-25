using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform weapon;
    private float offset = 180;

    public Transform shotPoint;
    public GameObject projectile;

    public float timeBetweenShot;
    float nextTimeShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle + offset);

        if (Input.GetMouseButton(0))
        {
            Shoot();
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
}
