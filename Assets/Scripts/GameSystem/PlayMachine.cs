using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMachine : IHaveHealth
{
    public override void TakeHit(float power)
    {
        StateMachine statemacine = FindObjectOfType<StateMachine>();

        if(statemacine != null)
        {
            statemacine.Play();
        }
    }

}
