using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State state;

    public void SetState(State _state)
    {
        state = _state;
        StartCoroutine(state.Start());
    }

    public void Start()
    {
        StartCoroutine(state.Start());
    }

    public void OnPauseButton()
    {
        StartCoroutine(state.PauseGame());
    }
    public void OnResumeButton()
    {
        StartCoroutine(state.ResumeGame());
    }
    public void OnGameOver()
    {
        StartCoroutine(state.GameOver());
    }




}
