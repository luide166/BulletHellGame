using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    
    private float timeBetweenAttack;
    [Header("Hit System")]
    public float hitTimer;
    public Transform hitPivot;
    public Transform hitPosition;
    public SpriteRenderer hitRenderer;

    public bool canAttack;
    public bool canBuild;

    [Header("Attack System")]
    public Color attackCollor;
    public LayerMask whatToAttack;
    public float attackRange;
    [SerializeField]
    private float knockbackPower = 16;

    [Header("Build System")]
    public Color buildCollor;
    public LayerMask whatToBuild;
    public float buildRange;



    // Start is called before the first frame update
    void Start()
    {
        SetAttackWeapon();
        hitRenderer = hitPosition.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectWeapon();
        RotateWeapon();

        if (timeBetweenAttack <=0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
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

        hitPivot.right = direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPosition.position, attackRange);
    }
    private void Attack()
    {
        if (canAttack)
        {
            AttackHit();
        }
        else if (canBuild)
        {
            BuildHit();
        }
	}

    private void AttackHit()
    {
        Collider2D[] thingsToattack = Physics2D.OverlapCircleAll(hitPosition.position, attackRange, whatToAttack);
        for (int i = 0; i < thingsToattack.Length; i++)
        {
            print(thingsToattack[i].name);
            Vector2 knockDir = (thingsToattack[i].transform.position - transform.position).normalized;
            thingsToattack[i].GetComponent<IHaveHealth>().TakeHit(knockbackPower, knockDir);
            timeBetweenAttack = hitTimer;
        }
    }

    private void BuildHit()
    {
        Collider2D[] thingsToBuild = Physics2D.OverlapCircleAll(hitPosition.position, buildRange, whatToBuild);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print($"build {thingsToBuild.Length}");
            for (int i = 0; i < thingsToBuild.Length; i++)
            {
                thingsToBuild[i].GetComponent<IHaveHealth>().TakeHit(1);
            }
        }
    }


    void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //activate attack weapon
            print("agora ataca");
            SetAttackWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //activate build weapon
            print("agora builda");
            SetBuildWeapon();
        }
    }

    void SetAttackWeapon()
    {
        SetOffWeapons();
        canAttack = true;
        hitRenderer.color = attackCollor;
    }

    void SetBuildWeapon() 
    {
        SetOffWeapons();
        canBuild = true;
        hitRenderer.color = buildCollor;
    }

    void SetOffWeapons()
    {
        canAttack = false;
        canBuild = false;
    }


}
