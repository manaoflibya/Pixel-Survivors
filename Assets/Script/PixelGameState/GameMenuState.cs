using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenuState : GameState
{
    public GameMenuState() 
    { 

    }

    public override void OnEnter()
    {
        SoundManager.Instance.BGMPlay(SoundManager.Instance.soundData.homeSoundClip);
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.homeMenuUIModel);
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {
        SoundManager.Instance.BGMPlayStop();
    }
}
