using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractWeapon : MonoBehaviour
{
    [SerializeField] private string weaponName;
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Image sprite;

    public void Shoot()
    {
        if (this.projectile == null)
        {
            return;
        }

        var newProjectile = Instantiate(this.projectile, transform.position, Quaternion.identity);
        if (newProjectile.TryGetComponent<Projectile>(out var projectile))
        {
            if (projectile.TryGetComponent<Rigidbody>(out var projectileRB)) 
            {
                Debug.Log("Shoot");
                projectileRB.AddForce(transform.up * projectile.GetVelocity());
            }
        }
    }

    public string GetWeaponName()
    {
        return weaponName;
    }

    public int GetDamage()
    {
        return damage;
    }

    public float GetFireRate()
    {
        return fireRate;
    }
}