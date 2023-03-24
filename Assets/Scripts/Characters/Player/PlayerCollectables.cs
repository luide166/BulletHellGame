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

    public void AddCoins(int amount)
    {
        coins += amount;
        UIManager.instance.ChangeCoinText(coins);
    }

    public void SpendCoins(int amount)
    {
        if(amount<= coins)
        {
            coins -= amount;
            UIManager.instance.ChangeCoinText(coins);
        }

    }

    public void AddScrews(int amount)
    {
        screws += amount;
        UIManager.instance.ChangeScrewText(screws);
    }

    public void SpendScrews(int amount)
    {
        screws -= amount;
        UIManager.instance.ChangeScrewText(screws);
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
