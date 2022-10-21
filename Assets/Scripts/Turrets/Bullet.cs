using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

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

    private void DealDamage()
    {
        IHaveHealth health = GetComponent<IHaveHealth>();
    }
}
