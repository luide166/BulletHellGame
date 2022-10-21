using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class IHaveHealth : MonoBehaviour
{

    int currentHealth;


    public virtual void TakeDamage(int _amount)
    {
        currentHealth -= _amount;
    }

    public virtual void SetHealth(int _MaxHealth)
    {
        currentHealth = _MaxHealth;
    }

    public virtual void TakeHit()
    {
        Debug.Log("Tomei um Hit");
    }

    public virtual void Die() 
    { 
    
    }
}
