using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySettingUIModel : GameUIModel
{
    private PlaySettingUIView view = null;

    public PlaySettingUIModel()
    {
        view = UnityEngine.Object.FindObjectOfType<PlaySettingUIView>();   

        if(view != null)
        {
            this.Go = view.go;
            this.Name = view.name;
            this.PlayButton = view.playButton;
            this.SoundButton = view.soundButton;
            this.HomeButton = view.homeButton;
        }
    }

    public override string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public override GameObject Go
    { 
        get { return this.go; } 
        protected set { this.go = value; }
    }

    private Button playButton = null;
    public Button PlayButton
    {
        set { this.playButton = value; }
        get { return this.playButton; }
    }

    private Button soundButton = null;
    public Button SoundButton
    {
        set { this.soundButton = value; }
        get { return this.soundButton; }
    }

    private Button homeButton = null;
    public Button HomeButton
    {
        set { this.homeButton = value; }
        get { return this.homeButton; }
    }

    public override void Hide()
    {
        if (this.Go != null)
        {
            this.Go.SetActive(false);
        }
        else
        {
            throw new System.Exception("Go is null");
        }
    }

    public override void Init()
    {
        //button에 등록된 Listeners 초기화
        HomeButton.onClick.RemoveAllListeners();
        SoundButton.onClick.RemoveAllListeners();
        PlayButton.onClick.RemoveAllListeners();

        PlayButton.onClick.AddListener(() => ClickPlayButton());
        SoundButton.onClick.AddListener(() => ClickSoundButton());
        HomeButton.onClick.AddListener(() => ClickHomeButton());

        Hide();
    }

    public override void Show()
    {
        if (this.Go != null)
        {
            this.Go.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            throw new System.Exception("Go is null");
        }
    }

    private void ClickSoundButton()
    {
        Debug.Log("SoundButton 기능 추가 ");

    }

    private void ClickHomeButton()
    {
        Time.timeScale = 1f;

        PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMELOADSTATE);
    }

    private void ClickPlayButton()
    {
        //UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playSettingUIModel);
        UIPresenter.Instance.NotUseModelClassList(this);
        Time.timeScale = 1f;
    }


    public override void UpdateInfo()
    {

    }
}
