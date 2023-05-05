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
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.MOVE);
        }
    }

    public override void OnExit()
    {
        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playJoyStickModel);
    }
}
