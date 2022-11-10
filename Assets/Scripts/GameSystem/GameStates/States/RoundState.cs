using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundState : State
{
    public RoundState(GameStateSystem _system) : base(_system)
    {
    }

    public override IEnumerator StartState()
    {

        //Change Text
        UIManager.instance.ChangeRoundText(gameState.waveSpawner.waveCount);

        //Generate Enemies
        gameState.waveSpawner.GenerateEnemiesToSpawn();


        Debug.LogWarning("CountDown 5 Seconsds - Enemy Check");
        yield return new WaitForSeconds(5);
        Debug.Log("Espero que tenha inimigo");


        //While have enemies wait
        do
        {
            Debug.Log("Tem inimigo");
        } while (gameState.HaveEnemies());

        yield return new WaitForSeconds(2);

        gameState.SetState(new WaitRoundState(gameState));

    }


}
