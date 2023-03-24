using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : IHaveHealth
{
    [SerializeField]
    private int maxhealth;

    [SerializeField]
    private GameObject buildSlotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeHit(float hitPower)
    {
        currentHealth -= hitPower;
        if(currentHealth <= 0)
        {
            Die();
        }
        base.TakeHit(hitPower);
    }

    public override void Die()
    {
        base.Die();
        Instantiate(buildSlotPrefab,transform.position,transform.rotation);
    }
}
