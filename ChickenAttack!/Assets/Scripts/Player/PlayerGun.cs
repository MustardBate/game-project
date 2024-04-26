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

    private int maxAmmo = 6;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle + offset);

        if (isReloading) 
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        //Need to update to work with holding down mouse 
        if (Input.GetMouseButton(0) && Time.time > nextTimeShot)
        {
            nextTimeShot = Time.time + timeBetweenShot;
            Shoot();
        }
    }

    private void Shoot()
    {
        currentAmmo--;
        Debug.Log("Current ammo: " + currentAmmo);
        Instantiate(projectile, shotPoint.position, shotPoint.rotation);

        CinemachineShake.Instance.ShakeCamera(5f, .1f);
    }
    
    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading");

        yield return new WaitForSeconds(reloadTime - .25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }
}
