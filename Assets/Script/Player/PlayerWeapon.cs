using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private AbstractWeapon currentWeapon;
    private bool canShoot = true;
    private float shootCD;
    private float currentTime;

    private void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            currentWeapon.Shoot();
            canShoot = false;
            shootCD = currentWeapon.GetFireRate();
            currentTime = 0;
            return;
        }

        currentTime += Time.deltaTime;
        if (currentTime >= shootCD)
        {
            canShoot = true;
        }
    }
}
