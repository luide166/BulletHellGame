using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.UI.CanvasScaler;

public class EnemyHealth : IHaveHealth
{

    public static event Action EnemyDead;
    [SerializeField]
    private int maxHealth;
    Rigidbody2D rb;

    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private int coinMultiplier;


    void Start()
    {
        SetHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    public override IEnumerator TakeBullet()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
            yield break;
        }

        yield return new WaitForSeconds(.2f);
    }

    public override void TakeHit(float knockPower, Vector2 knockDir)
    {
        //move ele de lugar
        StartCoroutine(Knockback(knockPower, knockDir));
    }

    public override void Die()
    {
        base.Die();
        EnemyDead();
        for (int i = 0; i < (maxHealth * DropAmount()); i++)
        {
          Instantiate(coin, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    public IEnumerator Knockback(float knockPower,Vector2 knockDir)
    {
        float timer = 0;
        float knockDur = (knockPower / (rb.mass * 1.5f));

        while(knockDur> timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(knockDir * knockPower, ForceMode2D.Impulse);
        }


        yield return new WaitForSeconds(1);
    }

    public int DropAmount()
    {
        int amount = 0;
        amount = maxHealth * coinMultiplier;

        return amount;
    }

}
