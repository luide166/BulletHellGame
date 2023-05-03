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

        transform.position += transform.right  * (speed / 10) * Time.deltaTime;
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
            if (otherHaveHealth.gameObject.CompareTag("Player") || otherHaveHealth.gameObject.CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    private void DealDamage(IHaveHealth _haveHealth)
    {
        IHaveHealth health = _haveHealth;
        StartCoroutine(health.TakeBullet());
    }
}
