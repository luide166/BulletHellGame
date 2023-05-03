using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlot : MonoBehaviour
{
    private SpriteRenderer renderer;

    public GameObject turret;
    public bool canBuild;

    [Header("Player is Near?")]
    [SerializeField]
    private GameObject player;
    private bool isNear;
    public float minDistance;

    void Start()
    {
        player = FindObjectOfType<PlayerAttack>().gameObject;
        renderer = GetComponent<SpriteRenderer>();
        canBuild = true;
        TurretHealth.TurretDead += TurretDestroyed;
    }

    void Update()
    {
        if (canBuild)
        {
            if (PlayerIsNear())
            {
                print("Ta perto");

                ActivateUI();
            }
            else if (PlayerGoneAway())
            {
                HideUI();
            }
        }
        else
        {
            HideUI();
        }
    }

    bool PlayerIsNear()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (distance <= minDistance)
            {
                isNear = true;
                return true;

            }
            else
            {
                return false;
            }
        }
        return false;
    }

    bool PlayerGoneAway()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (isNear)
            {
                if (distance >= minDistance)
                {
                    isNear = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

    private void ActivateUI()
    {
        bool _canBuild = player.GetComponent<PlayerAttack>().canBuild;

        if (_canBuild)
        {
            UIManager.instance.ActivateShopUI(this.transform);
        }
        else
        {
            HideUI();
        }
    }

    private void HideUI()
    {
        UIManager.instance.DesactivateShopUI();
    }

    public void TurretDestroyed()
    {
        canBuild = true;
        renderer.enabled = true;
    }

    public void BuildTurret(Vector3 _offset, GameObject turretToBuild)
    {
        Vector3 positionToBuild = transform.position + _offset;
        turret = Instantiate(turretToBuild, positionToBuild, Quaternion.identity);

        canBuild = false;
        renderer.enabled = false;
    }
}
