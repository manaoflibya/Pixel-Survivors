using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStopState : GameState
{
    public GameStopState() 
    {

    }

    public override void OnEnter()
    {
        Debug.Log(" StopState OnEnter");
    }

    public override void OnExit()
    {
        Debug.Log(" StopState OnExit");
    }

    public override void OnUpdate()
    {
        Debug.Log(" StopState OnUpdate");
    }
}
