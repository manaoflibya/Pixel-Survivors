using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class HomeMenuUIModel : GameUIModel
{
    private HomeMenuUIView view = null;

    public HomeMenuUIModel()
    {
        view = UnityEngine.Object.FindObjectOfType<HomeMenuUIView>();

        if (view != null)
        {
            this.Go = view.gameObject;
            this.Name = view.name;
            this.PlayButton = view.playButton;
            this.StopButton = view.stopButton;
            this.SettingButton = view.settingButton;
            this.GoldButton = view.goldButton;
        }
        else
        {
            throw new System.Exception("Check GamePlayUIModel");
        }
    }

    public override string Name
    {
        protected set { this.name = value; }
        get { return this.name; }
    }

    public override GameObject Go
    {
        protected set { this.go = value; }
        get { return this.go; }
    }

    private Button playButton = null;
    public Button PlayButton
    {
        get { return this.playButton; }
        set { this.playButton = value; }
    }

    private Button settingButton = null;
    public Button SettingButton
    {
        get { return this.settingButton; }
        set { this.settingButton = value; }
    }

    private Button stopButton = null;
    public Button StopButton
    {
        get { return this.stopButton; }
        set { this.stopButton = value; }
    }

    private Button goldButton = null;
    public Button GoldButton
    {
        get { return this.goldButton; }
        set { this.goldButton = value; }
    }


    //////////////////////

    public override void Init()
    {
        PlayButton.onClick.RemoveAllListeners();
        SettingButton.onClick.RemoveAllListeners();
        StopButton.onClick.RemoveAllListeners();
        GoldButton.onClick.RemoveAllListeners(); 

        PlayButton.onClick.AddListener(()=> ClickPlayButton());
        SettingButton.onClick.AddListener(()=> ClickSettingButton());
        StopButton.onClick.AddListener(()=> ClickStopButton());
        GoldButton.onClick.AddListener(()=> ClickGoldButton());

        Hide();
    }

    public override void Show()
    {
        if (this.Go != null)
        {
            this.Go.SetActive(true);
        }
        else
        {
            throw new System.Exception("Go is null");
        }
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

    private void ClickPlayButton()
    {
        SoundManager.Instance.EffectPlay(SoundManager.Instance.soundData.playButtonClickSoundClip, Vector3.zero);

        PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMELOADSTATE);
    }

    private void ClickSettingButton()
    {
        Debug.Log("Need Method ClickSettingButton");
        SoundManager.Instance.EffectPlay(SoundManager.Instance.soundData.uiButtonClickSoundClip, Vector3.zero);

    }

    private void ClickStopButton()
    {
        PixelGameManager.Instance.GameQuit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void ClickGoldButton()
    {
        SoundManager.Instance.EffectPlay(SoundManager.Instance.soundData.uiButtonClickSoundClip, Vector3.zero);

        Debug.Log("Need Method ClickGoldButton");
    }

    public override void UpdateInfo()
    {

    }
}
