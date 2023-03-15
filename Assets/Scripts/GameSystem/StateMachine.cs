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
        waveSpawner = GetComponent<WaveSpawner>();

        currentState = beginState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetState(State _state)
    {
        currentState = _state;
        currentState.EnterState(this);
    }
}
