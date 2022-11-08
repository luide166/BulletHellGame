using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using TMPro;

public class GameStateSystem : StateMachine
{
    private State currentState;

    public WaveSpawner waveSpawner;
    [SerializeField]
    private TextMeshProUGUI waveCount; 

    public void Awake()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        SetState(new StartGameState(this));
    }

    public void Start()
    {
    }

    public void OnPlayButton()
    {
        StartCoroutine(currentState.PlayButton());
        ChangeRoundText();
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

    public void ChangeRoundText()
    {
        waveCount.text = "Round: " + waveSpawner.waveCount.ToString();
    }


}
