using System;
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
    private bool isLoaded = false;

    public override void OnEnter()
    {
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.loadUIModel);

        if(SceneContoller.constant.currentSceneName == SceneContoller.constant.homeSceneName)
        {
            //PixelGameManager.Instance.sceneController.ChangeGamePlayScene();
        }
        else if(SceneContoller.constant.currentSceneName == SceneContoller.constant.gameplaySceneName)
        {
            //PixelGameManager.Instance.sceneController.ChangeHomeScene();
        }

        isLoaded = false;
        currentLoadTime = 0f;
    }

    public override void OnUpdate()
    {
        if(isLoaded.Equals(true))
        {
            return;
        }

        currentLoadTime += Time.deltaTime;
        if(currentLoadTime >= sceneLoadTime)
        {
            isLoaded = true;
            if (SceneContoller.constant.currentSceneName == SceneContoller.constant.homeSceneName)
            {
                void FinishMothod()
                {
                    PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMEPLAYSTATE);
                }

                PixelGameManager.Instance.sceneController.ChangeGamePlayScene(FinishMothod);
            }
            else if (SceneContoller.constant.currentSceneName == SceneContoller.constant.gameplaySceneName)
            {
                void FinishMothod()
                {
                    PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMEMENUSTATE);
                }

                PixelGameManager.Instance.sceneController.ChangeHomeScene(FinishMothod);
            }
         }
    }

    public override void OnExit()
    {
        //UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.homeMenuUIModel);

       // UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.loadUIModel);
       UIPresenter.Instance.RemoveAllUseUiList();
    }
}
