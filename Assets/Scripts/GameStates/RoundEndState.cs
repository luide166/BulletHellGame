using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : State
{
    //Set Up Next Wave
    public RoundEndState(GameStateSystem system) : base(system)
    {

    }

    public override IEnumerator Start()
    {
        gameState.waveSpawner.SetUpSpawner(); 
        yield break;
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
}
