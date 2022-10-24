using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    int damage;
    [SerializeField]
    float speed; 
    [SerializeField]
    float destroyTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("AutoDestroy", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.forward;

        transform.position += transform.right  * (speed / 10) * Time.fixedDeltaTime;
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        IHaveHealth otherHaveHealth = other.gameObject.GetComponent<IHaveHealth>();
        if (otherHaveHealth != null)
        {
            DealDamage(otherHaveHealth);
            Destroy(this.gameObject);
        }
        else
        {

        }
    }

    private void DealDamage(IHaveHealth _haveHealth)
    {
        IHaveHealth health = _haveHealth;
        StartCoroutine(health.TakeBullet());
    }
}
