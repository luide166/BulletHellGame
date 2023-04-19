using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreBuildTurret : IHaveHealth
{
    [Header("Turret Built")]
    public GameObject turretToBuild;
    public int builtLevel;
    public int maxBuiltLevel;
    private SpriteRenderer turretSprite;

    public Sprite[] turretsLevelSprite;


    void Start()
    {
        turretSprite = GetComponentInChildren<SpriteRenderer>();
        currentHealth = 1;
        builtLevel = 0;
        turretSprite.sprite = turretsLevelSprite[builtLevel];
    }

    public override void TakeHit(float hitPower)
    {
        if (builtLevel == maxBuiltLevel-1) 
        {
            Instantiate(turretToBuild, transform.position,transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            builtLevel++;
            turretSprite.sprite = turretsLevelSprite[builtLevel];
        }
    }
}
