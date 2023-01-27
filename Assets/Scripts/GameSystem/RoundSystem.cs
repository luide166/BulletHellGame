using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : StateMachine
{
    public WaveSpawner waveSpawner;
    public int roundCount;

    private void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        roundCount = waveSpawner.waveCount;
        SetState(new BeginState(this));
    }

    public void OnPlayButton()
    {
        StartCoroutine(state.PlayButton());
    }

    public void OnPauseButton()
    {
        StartCoroutine(state.PauseButton());
    }
    public void OnRoundEnd()
    {

    }
    public void OnGameOver()
    {

    }
}
