using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBackFeedback : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float strenght = 16, delay = 0.15f;

    public UnityEvent OnApplyKnockback, OnDoneKnockback;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayKnockback(GameObject attacker)
    {
        StopAllCoroutines();
        OnApplyKnockback?.Invoke();
        Vector2 direction = (transform.position - attacker.transform.position).normalized;
        rb.AddForce(direction * strenght, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector2.zero;
        OnDoneKnockback?.Invoke();
    
    }

}
