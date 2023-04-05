using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLauncher : MonoBehaviour, ILauncher
{
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private Transform[] firePoints;
    private int firePointCount;

    public void Idle(Turret turret)
    {
        
    }

    public void Launch(Turret turret)
    {
        Instantiate(bulletPrefab, firePoints[firePointCount].position, firePoints[firePointCount].rotation);
        firePointCount++;

        if(firePointCount == firePoints.Length )
        {
            firePointCount = 0;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        firePointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
