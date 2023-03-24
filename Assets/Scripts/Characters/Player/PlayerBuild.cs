using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    private float timeBetweenBuild;
    public float buildTimer;

    public Transform buildPivot;
    public Transform buildPosition;
    public LayerMask whatToBuild;
    public float buildRange;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();
        if(timeBetweenBuild <= 0)
        {
            Collider2D[] thingsToBuild = Physics2D.OverlapCircleAll(buildPosition.position, buildRange, whatToBuild);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print($"build {thingsToBuild.Length}");
                for (int i = 0; i < thingsToBuild.Length; i++)
                {
                    thingsToBuild[i].GetComponent<IHaveHealth>().TakeHit(1);
                }
            }
        }
        else
        {
            timeBetweenBuild -= Time.deltaTime;
        }
        
    }
    private void RotateWeapon()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(worldPos.x - transform.position.x, worldPos.y - transform.position.y);

        buildPivot.right = direction;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(buildPosition.position, buildRange);
    }
}
