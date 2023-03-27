using System.Collections;
using UnityEngine;

public class BeginState : State
{
    
    public override void EnterState(StateMachine state)
    {
        Debug.Log("Begin State");
        //configurar o spawner (Interface integrada) OK
        //não deixar as torres Atirarem
        //configurar a vida do Jogador

        state.waveSpawner.StartSpawner();
        state.StopShootingTurrets();
        UIManager.instance.ChangeRoundText(state.waveSpawner.RoundCount());

        
    }

    public override void PlayButton(StateMachine state)
    {
        // Se apertar play Vai pro Round
        state.waveSpawner.canSpawn = true;
        state.SetState(state.roundState);
    }

    public override void UpdateState(StateMachine state)
    {
        Debug.Log("Update Begin State");

    }

    public override void PauseButton(StateMachine state)
    {

    }

    public override void GameOver(StateMachine state)
    {
        throw new System.NotImplementedException();
    }
}