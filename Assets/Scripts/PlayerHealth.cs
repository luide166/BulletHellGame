﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerHealth : CharacterHealth
{
    [SerializeField]
    private int maxHealth;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeDamage(1);
        }
    }

    public override void TakeDamage(int _amount)
    {
        base.TakeDamage(_amount);
    }

    public override void SetHealth(int _MaxHealth)
    {
        base.SetHealth(_MaxHealth);
    }
}