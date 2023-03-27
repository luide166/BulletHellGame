using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlot : MonoBehaviour
{
    public float minDistance;

    [SerializeField]
    private GameObject player;

    private bool isNear;

    void Start()
    {
        player = FindObjectOfType<PlayerAttack>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerIsNear())
        {
            print("Ta perto");

            ActivateUI();
        }
        else if(PlayerGoneAway())
        {
            HideUI();
        }

    }

    bool PlayerIsNear()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);

        if(distance <= minDistance)
        {
            isNear = true;
            return true;
        
        }
        else
        {
            return false;
        }
    }

    bool PlayerGoneAway()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (isNear)
        {
            if(distance >= minDistance)
            {
                isNear = false;
                return true;
            }
            else
            {
                return false;
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
}
