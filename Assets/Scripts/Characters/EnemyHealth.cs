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

    [Header("Drop Amount")]
    [SerializeField]
    private GameObject[] itensToDrop;

    [SerializeField]
    private int amount;



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
            DropCollectables();
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

        Destroy(gameObject);
    }

    public IEnumerator Knockback(float knockPower,Vector2 knockDir)
    {
        float timer = 0;
        float knockDur = (knockPower / (rb.mass));

        while(knockDur> timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(knockDir * knockPower, ForceMode2D.Impulse);
        }


        yield return new WaitForSeconds(1);
    }


    private void DropCollectables()
    {
        for (int i = 0; i < amount; i++)
        {
            int item = UnityEngine.Random.Range(0, itensToDrop.Length);
            Instantiate(itensToDrop[item], transform.position, Quaternion.identity);
        }
    }
}
