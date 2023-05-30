using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopState : PlayerState
{
    public PlayerStopState()
    {

    }

    private PlayerData playerData;


    public override void OnEnter(PlayerData _playerData)
    {
        playerData = _playerData;

        PlayerController.Instance.PlayerWinAnim();
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
    }
}
