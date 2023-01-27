using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State state;

    public void SetState(State _state)
    {
        state = _state;
        print(state.ToString());
        StartCoroutine(state.StartState());
    }

}
