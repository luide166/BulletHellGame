using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected readonly GameStateSystem gameState;

    public State(GameStateSystem _system)
    {
        gameState = _system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator PauseGame()
    {
        yield break;
    }
    public virtual IEnumerator ResumeGame()
    {
        yield break;
    }

    public virtual IEnumerator GameOver()
    {
        yield break;
    }
}
