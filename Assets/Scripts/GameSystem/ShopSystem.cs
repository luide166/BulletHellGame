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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyQuadTurret()
    {
        PlayerCollectables player = FindObjectOfType<PlayerCollectables>();
        if(player != null) 
        {
            if (player.CanSpendScrews(quadTurretCost))
            {
                Instantiate(quadTurretPrefab, UIManager.instance.WhereToBuild().position+offset, UIManager.instance.WhereToBuild().rotation);
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
                Instantiate(turnTurretPrefab, UIManager.instance.WhereToBuild().position, UIManager.instance.WhereToBuild().rotation);
            }
        }
    }

}
