using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float time, deathTimer;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > deathTimer)
        {
            Destroy(gameObject);
        }
    }

    public float GetVelocity()
    {
        return velocity;
    }
}