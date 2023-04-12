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
        state.waveSpawner.canSpawn= true;
        state.StartShootingTurrets();
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
        state.StartShootingTurrets();

        if (state.waveSpawner.canSpawn == false)
        {
            Debug.Log("Spawnou Todos");
            if(state.waveSpawner.aliveEnemyCount ==0)
            {
                Debug.Log("Matou Todos");
                state.StopShootingTurrets();
                state.SetState(state.preRoundState);
            }
        }
    }

}