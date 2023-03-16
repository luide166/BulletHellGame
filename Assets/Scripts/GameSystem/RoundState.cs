using System.Collections;
using UnityEngine;
public class RoundState : State
{

    public override void EnterState(StateMachine state)
    {
        //
        //
        //
        //Verificar se os inimigos foram Eliminados
        //Se as vidas acabarem Game Over
        //
        Debug.Log("Round State");
        state.waveSpawner.canSpawn= true;
    }

    public override void GameOver(StateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void PauseButton(StateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void PlayButton(StateMachine state)
    {
        Debug.Log("PlayButon no Round");

    }

    public override void UpdateState(StateMachine state)
    {
        Debug.Log("update round");

    }
}