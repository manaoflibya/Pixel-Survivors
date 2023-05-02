using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState() 
    {

    }   

    public override void OnEnter(PlayerData _playerData)
    {
        Debug.Log("PlayerMoveState OnEnter Test");
    }

    public override void OnUpdate()
    {
        Debug.Log("PlayerMoveState OnUpdate Test");
    }
    public override void OnExit()
    {
        Debug.Log("PlayerMoveState OnExit Test");

    }

}
