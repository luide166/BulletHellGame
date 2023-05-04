using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    [SerializeField]
    private int coins;
    private int totalCoinsCollected;
    [SerializeField]
    private int screws;
    private int totalScrewsCollected;

    void Start()
    {
        UIManager.instance.ChangeCoinText(coins);
        UIManager.instance.ChangeScrewText(screws);

        totalScrewsCollected = 0;
        totalCoinsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Collect Things
    public void AddCoins(int amount)
    {
        coins += amount;
        totalCoinsCollected += amount;
        UIManager.instance.ChangeCoinText(coins);
    }
    public void AddScrews(int amount)
    {
        screws += amount;
        totalScrewsCollected += amount;
        UIManager.instance.ChangeScrewText(screws);
    }

    #endregion

    #region Spend Collectables

    public bool CanSpendCoins(int amount)
    {
        bool canBuy = false;

        if (coins >= amount)
        {
            coins -= amount;
            UIManager.instance.ChangeCoinText(coins);
            canBuy = true;
        }

        return canBuy;
    }
    public bool CanSpendScrews(int amount)
    {
        bool canBuy = false;

        if (amount <= screws)
        {
            screws = screws - amount;
            UIManager.instance.ChangeScrewText(screws);
            canBuy = true;
        }

        return canBuy;
    }
    #endregion


    public int GetTotalCoinsColected()
    {
        return totalCoinsCollected;
    }

    public int GetTotalScrewsCollected()
    {
        return totalScrewsCollected;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
        if (collectable != null)
        {
            StartCoroutine(collectable.AddCollectable(this));
        }
    }

}
