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
            SoundManager.Instance.SoundPlayOneShot(SoundManager.Instance.soundData.gameLoseSoundClip);
            UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playGameOverUIModel);
            PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.END);
        }
        else
        {
            SoundManager.Instance.SoundPlayOneShot(SoundManager.Instance.soundData.gameWinSoundClip);
            UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playGameWinUIModel);
            PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.STOP);
        }

        PixelGameManager.Instance.playTimeContorller.StopGameTime();

    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        SoundManager.Instance.BGMPlayStop();

        PixelGameManager.Instance.monsterController.DeleteAllMonsters();
        PixelGameManager.Instance.itemController.DeleteAllItems();
    }
}
