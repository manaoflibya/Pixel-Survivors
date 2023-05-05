using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState() 
    {

    }   

    private PlayerData playerData;

    public override void OnEnter(PlayerData _playerData)
    {
        playerData = _playerData;   
        GameUIModel gameUIModel = UIPresenter.Instance.playJoyStickModel;
        UIPresenter.Instance.UseModelClassList(gameUIModel);
       // PlayerController.Instance.PlayerAnimationMove(true);
    }

    public override void OnUpdate()
    {
        if(UIPresenter.Instance.playJoyStickModel.Go.activeSelf) 
        {
            Vector3 dirVec = UIPresenter.Instance.playJoyStickModel.MoveVec;
            dirVec.Normalize();

            if(dirVec == Vector3.zero)
            {
                PlayerController.Instance.PlayerAnimationMove(false);
            }
            else
            {
                PlayerController.Instance.PlayerAnimationMove(true);
            }

            PlayerController.Instance.MovePlayerPosition(dirVec);
        }

        if(Input.GetMouseButtonUp(0)) 
        {
            PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.STOP);
        }
    }

    public override void OnExit()
    {
       // Debug.Log("<color=green>PlayerMoveState -> OnExit</color>");

        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playJoyStickModel);
    }
}
