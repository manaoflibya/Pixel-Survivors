using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBeginState : PlayerState
{
    private PlayerData playerData;
    
    public PlayerBeginState() 
    {

    }

    public override void OnEnter(PlayerData _playerData)
    {
        playerData = _playerData;
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}
