using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Transform weapon;

    public Transform shotPoint;
    public GameObject projectile;

    public float timeBetweenShot = .5f;
    float nextTimeShot;

    private int maxAmmo = 6;
    private int currentAmmo;
    public float reloadTime = 1.3f;
    private bool isReloading = false;

    public float ShakeIntensity = 4f;
    public float ShakeTime = .3f;

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
        weapon.rotation = Quaternion.Euler(0, 0, angle + 180);

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

            CameraShake.Instance.ShakeCamera(ShakeIntensity, ShakeTime);
        }
    }

    private void Shoot()
    {
        currentAmmo--;
        Debug.Log("Current ammo: " + currentAmmo);
        Instantiate(projectile, shotPoint.position, shotPoint.rotation);
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
