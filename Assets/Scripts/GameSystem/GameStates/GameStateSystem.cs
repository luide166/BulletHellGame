using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using TMPro;

public class GameStateSystem : StateMachine
{
    private State currentState;

    public WaveSpawner waveSpawner;

    public void Awake()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        currentState = new StartGameState(this);
        Debug.Log(currentState + " game system");
        SetState(currentState);
    }

    public void Start()
    {

    }

    public void RoundEnd()
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
