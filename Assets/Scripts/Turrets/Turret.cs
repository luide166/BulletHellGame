using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private ILauncher launcher;

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
        if (CanFire())
        {
            FireWeapon();
        }
        else
        {
            Idle();
        }
    }

    private bool CanFire()
    {
        return Time.time >= nextFireRate;
    }

    private void FireWeapon()
    {
        nextFireRate = Time.time + fireRate;
        launcher.Launch(this);
    }

    private void Idle()
    {
        launcher.Idle(this);
        print("Idle - Torre");
    }
}