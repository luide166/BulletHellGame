using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerHealth : IHaveHealth
{
    [SerializeField]
    private int maxHealth;

    
    void Start()
    {
        SetHealth(maxHealth);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("dano player");
            StartCoroutine(TakeBullet());
        }
    }

    public override IEnumerator TakeBullet()
    {
        currentHealth --;
        if(currentHealth <= 0)
        {
            Die();
            yield break;
        }
        //dar dano no player
    

        yield return new WaitForSeconds(0);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
