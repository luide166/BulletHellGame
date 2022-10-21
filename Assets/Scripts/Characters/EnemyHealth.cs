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

    public override void TakeDamage(int _amount)
    {
        base.TakeDamage(_amount);
    }

    public override void SetHealth(int _MaxHealth)
    {
        base.SetHealth(_MaxHealth);
    }

    public override void TakeHit()
    {
        base.TakeHit();
    }

    public override void Die()
    {

    }

}
