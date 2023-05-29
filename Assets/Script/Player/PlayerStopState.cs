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

        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playJoyStickModel);
        PlayerController.Instance.PlayerAnimationMove(false);
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playJoyStickModel);
    }
}
