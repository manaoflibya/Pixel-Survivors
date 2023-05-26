using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndState : PlayerState
{
    public PlayerEndState()
    {

    }

    public override void OnEnter(PlayerData _playerData)
    {
        PlayerController.Instance.PlayerDeadAnim();
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
    }
}
