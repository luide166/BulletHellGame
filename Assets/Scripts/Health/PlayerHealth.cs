using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class PlayerHealth : IHaveHealth
{
    [SerializeField]
    private float maxHealth;


    void Start()
    {
        SetHealth(maxHealth);
        UIManager.instance.ChangePlayerLife(maxHealth,currentHealth);
    }

    void Update()
    {
    }

    public override IEnumerator TakeBullet()
    {
        //dar dano no player
        currentHealth--;
        UIManager.instance.ChangePlayerLife(maxHealth, currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
            yield break;
        }

        yield return new WaitForSeconds(.02f);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }



}
