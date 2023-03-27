using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    State currentState;
    public BeginState beginState = new BeginState();
    public RoundState roundState = new RoundState();
    public PreRoundState preRoundState = new PreRoundState();

    public WaveSpawner waveSpawner;

    private void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();

        currentState = beginState;
        currentState.EnterState(this);
    }

    public void SetState(State _state)
    {
        currentState = _state;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void PlayButton(State _state)
    {
        currentState.PlayButton(this);
    }

    public void PauseButton(State _state)
    {
        currentState.PauseButton(this);
    }

    #region UI Button Method
    public void Play()
    {
        PlayButton(currentState);
    }
    #endregion

    #region Turrets Idle

    public void StopShootingTurrets()
    {
        Turret[] turret = FindObjectsOfType<Turret>();
        for (int i = 0; i < turret.Length; i++)
        {
            turret[i].idle = true;
        }
    }
    public void StartShootingTurrets()
    {
        Turret[] turret = FindObjectsOfType<Turret>();
        for (int i = 0; i < turret.Length; i++)
        {
            turret[i].idle = false;
        }

    }



    #endregion

}
