using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ICollectable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollectable();
    }
    public override IEnumerator AddCollectable(PlayerCollectables player)
    {
        player.AddCoins(value);
        Destroy(gameObject);
        yield break;
    }
}
