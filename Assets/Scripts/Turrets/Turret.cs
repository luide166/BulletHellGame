using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private ILauncher launcher;

    [SerializeField]
    bool idle;

    [SerializeField]
    float fireRate;
    float nextFireRate;
    
    // Start is called before the first frame update
    void Awake()
    {
        launcher = GetComponent<ILauncher>();
        nextFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CanShoot())
        {
            FireWeapon();
        }
        else
        {
            Idle();
        }
    }

    private bool CanShoot()
    {
        return Time.deltaTime >= nextFireRate;
    }

    private void FireWeapon()
    {
        nextFireRate = Time.deltaTime + fireRate;
        launcher.Launch(this);
    }

    private void Idle()
    {
        launcher.Idle(this);
        print("Idle - Torre");
    }
}