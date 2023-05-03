using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    private GameObject quadTurretPrefab;
    public int quadTurretCost;

    [SerializeField]
    private GameObject turnTurretPrefab;
    public int turnTurretCost;

    public void BuyQuadTurret()
    {
        PlayerCollectables player = FindObjectOfType<PlayerCollectables>();
        if(player != null) 
        {
            if (player.CanSpendScrews(quadTurretCost))
            {
                BuildSlot _buildSlot = UIManager.instance.GetBuildSlot();

                _buildSlot.BuildTurret(offset, quadTurretPrefab);
            }
        }
    }

    public void BuyTurnTurret()
    {
        PlayerCollectables player = FindObjectOfType<PlayerCollectables>();
        if (player != null)
        {
            if (player.CanSpendCoins(turnTurretCost))
            {
                BuildSlot _buildSlot = UIManager.instance.GetBuildSlot();

                _buildSlot.BuildTurret(offset, turnTurretPrefab);    
            }
        }
    }

}
