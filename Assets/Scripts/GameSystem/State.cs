using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class State
{
    public abstract void EnterState(StateMachine state);

    public abstract void UpdateState(StateMachine state);

    public abstract void  PlayButton(StateMachine state);
    public abstract void  PauseButton(StateMachine state);

    public  abstract void  GameOver(StateMachine state);

}
