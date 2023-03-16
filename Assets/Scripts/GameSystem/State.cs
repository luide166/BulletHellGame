using System.Collections;
using UnityEngine;

public abstract class State
{
    public abstract void EnterState(StateMachine state);

    public abstract void UpdateState(StateMachine state);

    public abstract void  PlayButton(StateMachine state);

    public abstract void  PauseButton(StateMachine state);

    public  abstract void  GameOver(StateMachine state);

}
