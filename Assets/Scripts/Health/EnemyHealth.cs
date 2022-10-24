using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : IHaveHealth
{
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
        Destroy(gameObject);
    }

}
