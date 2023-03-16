using System.Collections;
using System.Threading;
using UnityEngine;

public class BeginState : State
{
    
    public override void EnterState(StateMachine state)
    {
        Debug.Log("vsievueiunvi");
        //configurar o spawner (Interface integrada) OK
        //não deixar as torres Atirarem
        //configurar a vida do Jogador

        state.waveSpawner.StartSpawner();
        state.SetState(state.preRoundState);

    }
    public override void UpdateState(StateMachine state)
    {
        
    }

    public override void PauseButton(StateMachine state)
    {

    }

    public override void PlayButton(StateMachine state)
    {
        throw new System.NotImplementedException();
    }

    public override void GameOver(StateMachine state)
    {
        throw new System.NotImplementedException();
    }
}