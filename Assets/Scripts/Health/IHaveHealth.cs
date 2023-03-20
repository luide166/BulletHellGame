    using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class IHaveHealth : MonoBehaviour
{
    public float currentHealth;

    void Update()
    {
        if (currentHealth < 0)
        {

            Die();
        }
    }

    public void SetHealth(float _MaxHealth)
    {
        currentHealth = _MaxHealth;
    }

    public virtual IEnumerator TakeBullet()
    {
        yield break;
    }
    public virtual void TakeHit()
    {
        Debug.Log("Tomei um Hit");
    }
    public virtual void Die() 
    {
        Debug.Log("Morri" + name);
    }
}
