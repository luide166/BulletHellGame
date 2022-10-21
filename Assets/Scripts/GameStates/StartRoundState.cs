using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoundState : State
{
    //Spawn Wave
    public StartRoundState(GameStateSystem system) : base(system)
    {

    }

    public override IEnumerator Start()
    {
        gameState.waveSpawner.GenerateEnemies();
        yield return null;
    }

    public override IEnumerator PauseGame()
    {
        //Pausa o Game
        return base.PauseGame();
    }

    public override IEnumerator ResumeGame()
    {
        //Retorna pro Jogo
        return base.ResumeGame();
    }

    public override IEnumerator GameOver()
    {
        //Perde o Jogo
        return base.GameOver();
    }
}
