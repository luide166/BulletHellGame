using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : State
{
    public StartGameState(GameStateSystem _system) : base(_system)
    {

    }

    public override IEnumerator Start()
    {
        gameState.waveSpawner.StartSpawner();
        Debug.Log("Start Game State");

        return base.Start();
    }

    public override IEnumerator PlayButton()
    {
        gameState.SetState(new RoundState(gameState));
        
        return base.PlayButton();
    }

}
