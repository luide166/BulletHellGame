using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] 
    int currentHealth;

    public virtual void TakeDamage(int _amount)
    {
        currentHealth -= _amount;
    }

    public virtual void SetHealth(int _MaxHealth)
    {
        currentHealth = _MaxHealth;
    }
}
