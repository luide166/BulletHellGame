using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMachine : IHaveHealth
{
    public override void TakeHit(float power)
    {
        print("tomei o hit");
        StateMachine statemacine = FindObjectOfType<StateMachine>();

        if(statemacine != null)
        {
            print("tem state machine");
            statemacine.Play();
        }
    }

}
