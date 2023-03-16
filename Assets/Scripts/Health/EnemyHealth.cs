using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : IHaveHealth
{
    public static event Action Dead;
    [SerializeField]
    private int maxHealth;


    void Start()
    {
        SetHealth(maxHealth);
    }

    public override IEnumerator TakeBullet()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
            yield break;
        }

        yield return new WaitForSeconds(0);
    }

    public override void TakeHit()
    {
        base.TakeHit();
        //move ele de lugar
    }

    public override void Die()
    {
        base.Die();
        Dead();
        Destroy(gameObject);
    }

}
