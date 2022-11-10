using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State state;

    public void Start()
    {

    }


    public void SetState(State _state)
    {
        state = _state;
        Debug.LogError(state + " setted - FSM");
        StartCoroutine(state.StartState());
    }

    public void OnPlayButton()
    {
        Debug.LogError(state + " press play Button - FSM");
        StartCoroutine(state.PlayButton());
    }

    public void OnPauseButton()
    {
        Debug.LogError(state + " press pause Button - FSM");
        StartCoroutine(state.PauseGame());
    }
    public void OnResumeButton()
    {
        Debug.LogError(state + " press resume Button - FSM");
        StartCoroutine(state.ResumeGame());
    }
    public void OnGameOver()
    {
        Debug.LogError(state + " game Over - FSM");
        StartCoroutine(state.GameOver());
    }
}
