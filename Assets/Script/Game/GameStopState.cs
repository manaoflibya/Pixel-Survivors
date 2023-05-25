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
        UIPresenter.Instance.RemoveAllUseUiList();

        if(PlayerController.Instance.GetPlayerDead().Equals(true))
        {
            UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playGameOverUIModel);
        }
        else
        {
            UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playGameWinUIModel);
        }

        PixelGameManager.Instance.playTimeContorller.StopGameTime();
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
