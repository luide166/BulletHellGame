using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossLauncher : MonoBehaviour, ILauncher
{
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private Transform[] FirePoints;

    public void Launch(Turret turret)
    {
        for (int i = 0; i < FirePoints.Length; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, FirePoints[i].position, FirePoints[i].rotation);
        }
    }
    public void Idle(Turret turret)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
