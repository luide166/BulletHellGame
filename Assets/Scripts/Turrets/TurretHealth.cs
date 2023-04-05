using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : IHaveHealth
{
    [SerializeField]
    private int maxHealth;

    public static event Action TurretDead;

    private TurretDrop drop;

    private bool isBuilt;

    void Start()
    {
        SetHealth(maxHealth);
        drop = GetComponent<TurretDrop>();
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
        drop.DropColectables();

        Destroy(gameObject);
    }
}
