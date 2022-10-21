using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class GameStateSystem : StateMachine
{
    private State currentState;



    public WaveSpawner waveSpawner;


    public void Awake()
    {
        waveSpawner = GetComponent<WaveSpawner>();
    }

    public void Start()
    {
        currentState = GetComponent<State>();
        StartCoroutine(currentState.Start());
    }

    public void OnPauseButton()
    {
        StartCoroutine(currentState.PauseGame());
    }
    public void OnResumeButton()
    {
        StartCoroutine(currentState.ResumeGame());
    }

    public void OnGameOver()
    {
        //Perde o jogo
    }

}
