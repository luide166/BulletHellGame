using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : IHaveHealth
{
    [SerializeField]
    private int maxHealth;

    public static event Action TurretDead;

    void Start()
    {
        SetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator TakeBullet()
    {
        yield return null;
    }

    public override void TakeHit(float hitPower)
    {
        currentHealth -= hitPower;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        TurretDead();

        Destroy(gameObject);
    }
}
