using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class PlayerHealth : IHaveHealth
{
    [SerializeField]
    private int maxHealth;

    public Image healthBar;


    void Start()
    {
        SetHealth(maxHealth);
    }

    void Update()
    {

    }

    public override IEnumerator TakeBullet()
    {
        //dar dano no player
        currentHealth--;
        ChangeLife();
        if (currentHealth <= 0)
        {
            Die();
            yield break;
        }
        float health = currentHealth;
        float healthBarFillAmount = health / maxHealth;

        yield return new WaitForSeconds(.02f);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }


    public void ChangeLife()
    {
        healthBar.fillAmount =  currentHealth / maxHealth;
    }

}
