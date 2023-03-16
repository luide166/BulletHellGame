using System.Collections;
using UnityEngine;

public class PreRoundState : State
{
   

    public override void EnterState(StateMachine state)
    {
        Debug.Log("pre Round State");
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
       state.canSpawn = true;
    }

    public override void UpdateState(StateMachine state)
    {
        if(state.canSpawn)
        {
            state.SetState(state.roundState);
        }
    }
}