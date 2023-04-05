using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private ILauncher launcher;

    public bool idle;

    [SerializeField]
    float shootsPerMinute;
    float nextShoot;
    
    // Start is called before the first frame update
    void Awake()
    {
        launcher = GetComponent<ILauncher>();
        nextShoot = 60 / shootsPerMinute;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(idle == false) 
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
    }

    private bool CanShoot()
    {
        nextShoot += Time.deltaTime;

        return nextShoot >= 60 / shootsPerMinute;
    }

    private void FireWeapon()
    {
        launcher.Launch(this);
        nextShoot = 0;
    }

    private void Idle()
    {
        launcher.Idle(this);
        print("Idle - Torre");
    }
}