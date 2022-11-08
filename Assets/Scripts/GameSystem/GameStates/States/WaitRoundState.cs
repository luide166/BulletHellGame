using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitRoundState : State
{
    public WaitRoundState(GameStateSystem _system) : base(_system)
    {
    }

    public override IEnumerator Start()
    {
        gameState.waveSpawner.SetSpawner();
        gameState.ChangeRoundText();
        Debug.LogWarning("Waiting next round");
     
        return base.Start();
    }
    public override IEnumerator PlayButton()
    {
        gameState.SetState(new RoundState(gameState));

        return base.PlayButton();
    }

}
