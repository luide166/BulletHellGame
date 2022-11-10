using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitRoundState : State
{
    public WaitRoundState(GameStateSystem _system) : base(_system)
    {
    }

    public override IEnumerator StartState()
    {
        gameState.waveSpawner.SetSpawner();
        Debug.LogWarning("Waiting next round");
     
        return null;
    }
    public override IEnumerator PlayButton()
    {
        gameState.SetState(new RoundState(gameState));

        return null;
    }

}
