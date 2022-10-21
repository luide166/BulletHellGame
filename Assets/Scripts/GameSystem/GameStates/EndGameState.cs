using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : State
{
    //Game Over
    public EndGameState(GameStateSystem system) : base(system)
    {

    }

    public override IEnumerator Start()
    {
        //lose game menu
        return base.Start();
    }
}
