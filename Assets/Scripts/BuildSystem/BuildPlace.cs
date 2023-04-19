using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : IHaveHealth
{
    [Header("Build Stats")]
    [SerializeField]
    private int maxhealth;

    [SerializeField]
    private GameObject buildSlotPrefab;

    public Sprite[] sprites;
    private SpriteRenderer renderer;


    void Start()
    {
        SetHealth(maxhealth);
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[(int)currentHealth];
    }

    public override void TakeHit(float hitPower)
    {
        currentHealth -= hitPower;
        renderer.sprite = sprites[(int)currentHealth];

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        Instantiate(buildSlotPrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
