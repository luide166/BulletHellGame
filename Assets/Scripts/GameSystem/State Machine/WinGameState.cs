using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameState : State
{
    public override void EnterState(StateMachine state)
    {
        state.winGameScreen.SetActive(true);
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
        Debug.Log("Num pode dar Play");
    }

    public override void UpdateState(StateMachine state)
    {
        Debug.Log("Ganhou parabens uhul");
    }
}
