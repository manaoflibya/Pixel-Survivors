using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class UIPresenter : MonoSingleton<UIPresenter>  
{
    public UIPresenterData presenterData;
    public HomeMenuUIModel homeMenuUIModel;
    public LoadUIModel loadUIModel;
    public PlayJoyStickModel playJoyStickModel;
    public GamePlayUIModel gamePlayUIModel;
    public PlaySettingUIModel playSettingUIModel;
    public PlayLevelUpUIModel playLevelUpUIModel;
    public PlayGameOverUIModel playGameOverUIModel;
    public PlayGameWinUIModel playGameWinUIModel;


    private void Start()
    {
        InitUIPresenter();
    }

    private void Update()
    {
        if (presenterData.useModelList.Count > 0)
        {
            // ���� JoyStick Model�� �������
            presenterData.useModelList.ForEach(model => { model.UpdateInfo(); });
        }
    }


    private void InitUIPresenter()
    {
        homeMenuUIModel = new HomeMenuUIModel();

        if(homeMenuUIModel != null)
        {
            AddUIList(homeMenuUIModel);
        }

        loadUIModel = new LoadUIModel();

        if(loadUIModel != null)
        {
            AddUIList(loadUIModel);
        }

        playJoyStickModel = new PlayJoyStickModel();

        if (playJoyStickModel != null)
        {
            AddUIList(playJoyStickModel);
        }

        gamePlayUIModel = new GamePlayUIModel();

        if (gamePlayUIModel != null)
        {
            AddUIList(gamePlayUIModel);
        }

        playSettingUIModel = new PlaySettingUIModel();

        if(playSettingUIModel != null)
        {
            AddUIList(playSettingUIModel);
        }

        playLevelUpUIModel = new PlayLevelUpUIModel();

        if(playLevelUpUIModel != null)
        {
            AddUIList(playLevelUpUIModel);
        }        
        
        playGameOverUIModel = new PlayGameOverUIModel();

        if(playGameOverUIModel != null)
        {
            AddUIList(playGameOverUIModel);
        }

        playGameWinUIModel = new PlayGameWinUIModel();

        if (playGameWinUIModel != null)
        {
            AddUIList(playGameWinUIModel);
        }

    }

    /// <summary>
    /// Model Class�� �����ϸ� �ִ� List�� ���� �Լ�
    /// </summary>
    /// <param name="model"></param>
    private void AddUIList(GameUIModel model)
    {
        if(presenterData.modelList.Contains(model))
        {
            Debug.Log("already have " + model);
            return;
        }

        model.Init();
        presenterData.modelList.Add(model);
    }

    /// <summary>
    /// ���� Controller���� UI�� ����ϱ� ���ؼ� ��Ƶδ� List �Լ�
    /// </summary>
    /// <param name="model"></param>
    /// <returns>List �迭�� �ֱ� ��������</returns>
    public bool UseModelClassList(GameUIModel model)
    {
        if(presenterData.useModelList.Contains(model))
        {
            Debug.Log("already have " + model);

            return false;
        }

        model.Show();
        presenterData.useModelList.Add(model);

        return true;
    }

    
    public void RemoveUIList(GameUIModel model)
    {
        if(!presenterData.modelList.Contains(model))
        {
            Debug.Log("Don't have " + model);
            return; 
        }

        presenterData.modelList.Remove(model);
    }

    /// <summary>
    /// ���� ����ߴ� Model Class�� ���û���
    /// </summary>
    /// <param name="model"></param>
    /// <returns>��������</returns>
    public bool NotUseModelClassList(GameUIModel model)
    {
        if(!presenterData.useModelList.Contains(model))
        {
            Debug.Log("Don't have " + model);
            return false;
        }

        model.Hide();
        presenterData.useModelList.Remove(model);

        return true;
    }

    public bool RemoveAllUIList()
    {
        if(presenterData.modelList.Count == 0)
        {
            Debug.Log("Model List has nothing");
            return false;
        }

        presenterData.modelList.Clear();
        
        return true;
    }

    public bool RemoveAllUseUiList()
    {
        if (presenterData.useModelList.Count == 0)
        {
            Debug.Log("Model List has nothing");
            return false;
        }

        foreach(var data in presenterData.useModelList)
        {
            data.Hide();
        }

        presenterData.useModelList.Clear();

        return true;
    }

    public bool FindUseUIModel(GameUIModel model)
    {
        if(!presenterData.useModelList.Contains(model))
        {
            Debug.Log($"Don't have {model} List Data ");
            return false;
        }

        return true;
    }
}
