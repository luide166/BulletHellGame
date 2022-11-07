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
        SetState(new StartGameState(this)); 
    }

    public void OnPlayButton()
    {
        StartCoroutine(currentState.PlayButton());
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


    public void OnRoundEnd()
    {

    }

    public bool HaveEnemies()
    {
        bool _haveEnemies = false;
        EnemyHealth[] enemiesInScene = FindObjectsOfType<EnemyHealth>();

        if (enemiesInScene != null)
        {
            _haveEnemies = true;
        }

        return _haveEnemies;
    }

}
