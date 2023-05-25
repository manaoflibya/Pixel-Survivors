using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLoadState : GameState
{
    public GameLoadState()
    {
        
    }

    private float sceneLoadTime = 2f;
    private float currentLoadTime = 0f;

    public override void OnEnter()
    {
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.loadUIModel);

        if(SceneContoller.constant.currentSceneName == SceneContoller.constant.homeSceneName)
        {
            PixelGameManager.Instance.sceneController.ChangeGamePlayScene();
        }
        else if(SceneContoller.constant.currentSceneName == SceneContoller.constant.gameplaySceneName)
        {
            PixelGameManager.Instance.sceneController.ChangeHomeScene();
        }

        currentLoadTime = 0f;
    }

    public override void OnUpdate()
    {
        currentLoadTime += Time.deltaTime;
        if(currentLoadTime >= sceneLoadTime)
        {
            if (SceneContoller.constant.currentSceneName == SceneContoller.constant.homeSceneName)
            {
                PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMEPLAYSTATE);
            }
            else if (SceneContoller.constant.currentSceneName == SceneContoller.constant.gameplaySceneName)
            {
                PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMEMENUSTATE);
            }
         }
    }

    public override void OnExit()
    {
        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.loadUIModel);
    }
}
