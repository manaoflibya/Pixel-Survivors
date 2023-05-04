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
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playJoyStickModel);
    }

    public override void OnUpdate()
    {

    }
    public override void OnExit()
    {
        UIPresenter.Instance.RemoveUIList(UIPresenter.Instance.playJoyStickModel);
    }

}
