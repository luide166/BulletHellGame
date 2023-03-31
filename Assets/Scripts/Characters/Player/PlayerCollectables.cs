using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    [SerializeField]
    private int coins;
    [SerializeField]
    private int screws;

    void Start()
    {
        UIManager.instance.ChangeCoinText(coins);
        UIManager.instance.ChangeScrewText(screws);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Collect Things

    public void AddCoins(int amount)
    {
        coins += amount;
        UIManager.instance.ChangeCoinText(coins);
    }
    public void AddScrews(int amount)
    {
        screws += amount;
        UIManager.instance.ChangeScrewText(screws);
    }

    #endregion

    public bool CanSpendCoins(int amount)
    {
        bool canBuy = false;

        if (amount <= coins)
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

        if (amount <= coins)
        {
            screws -= amount;
            UIManager.instance.ChangeScrewText(coins);
            canBuy = true;
        }

        return canBuy;
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
