using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float attackTimer;

    public Transform attackPivot;
    public Transform attackPosition;
    public LayerMask whatToAttack;
    public float attackRange;

    [Header("Knockback Effect")]
    [SerializeField]
    private float attackPower = 16;

    public UnityEvent OnApplyKnockback, OnDoneKnockback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();

        if (timeBetweenAttack <=0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D[] thingsToHit = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatToAttack);
                for (int i = 0; i < thingsToHit.Length; i++)
                {
                    print(thingsToHit[i].name);
                    Vector2 knockDir = (thingsToHit[i].transform.position - transform.position).normalized;
                    thingsToHit[i].GetComponent<IHaveHealth>().TakeHit(attackPower, knockDir);
                    timeBetweenAttack = attackTimer;
                }
            }
            else
            {
                timeBetweenAttack -= Time.deltaTime;
            }
        }
    }

    private void RotateWeapon()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(worldPos.x - transform.position.x, worldPos.y - transform.position.y);

        attackPivot.right = direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
