using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : State
{
    public override void EnterState(StateMachine state)
    {
        state.gameOverScreen.SetActive(true);
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
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateMachine state)
    {
        Debug.Log("esperando reiniciar o game");
    }
}
