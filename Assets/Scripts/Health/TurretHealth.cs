using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : IHaveHealth
{
    [SerializeField]
    private int maxHealth;


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

    public override void TakeHit()
    {
        currentHealth--;
        if(currentHealth < 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
