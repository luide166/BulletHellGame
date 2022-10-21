using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    private WayPoints path;

    private int waypointIndex;


    void Start()
    {
        waypointIndex = 0;
        path = GameObject.FindGameObjectWithTag("AIPath").GetComponent<WayPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = path.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        if (Vector2.Distance(transform.position, path.waypoints[waypointIndex].position) < 0.4f)
        {
            if (waypointIndex < path.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                // damage player
                Destroy(gameObject);
            }
        }

    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, path.waypoints[waypointIndex].position, (speed/10) * Time.fixedDeltaTime);
        
    }
}