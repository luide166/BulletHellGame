using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : State
{
    
    public override void EnterState(StateMachine state)
    {
        Debug.Log("Begin State");
        //configurar o spawner (Interface integrada) OK
        //não deixar as torres Atirarem
        //configurar a vida do Jogador
        //Desligar a interface de GameOver

        state.waveSpawner.StartSpawner();
        state.gameOverScreen.SetActive(false);
        state.StopShootingTurrets();
        UIManager.instance.ChangeRoundText(state.waveSpawner.RoundCount());
        state.StopShootingTurrets();



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
        state.StopShootingTurrets();

    }

    public override void PauseButton(StateMachine state)
    {

    }

    public override void GameOver(StateMachine state)
    {
        throw new System.NotImplementedException();
    }
}