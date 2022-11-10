using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : State
{
    public StartGameState(GameStateSystem _system) : base(_system)
    {

    }

    public override IEnumerator StartState()
    {
        Debug.LogWarning("Start Game START - State");
        gameState.waveSpawner.StartSpawner();
        UIManager.instance.ChangeRoundText(gameState.waveSpawner.waveCount);

        yield break;
    }

    public override IEnumerator PlayButton()
    {
        Debug.LogWarning("Start Game PLAY BUTTON - State");
        yield return new WaitForSeconds(1);
        Debug.LogWarning("Begin Round");
        gameState.SetState(new RoundState(gameState));
    }

}
