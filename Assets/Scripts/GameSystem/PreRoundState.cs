using System.Collections;
using UnityEngine;

public class PreRoundState : State
{
   

    public override void EnterState(StateMachine state)
    {
        //Wait for Play Button OK
        //
        //
        //
        //
        Debug.Log("pre Round State");
        UIManager.instance.ChangeRoundText(state.waveSpawner.RoundCount());
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
       // Se apertar play pode Spawnar inimigos
       state.waveSpawner.canSpawn = true;
    }

    public override void UpdateState(StateMachine state)
    {
        if(state.waveSpawner.canSpawn)
        {
            state.SetState(state.roundState);
        }
    }
}