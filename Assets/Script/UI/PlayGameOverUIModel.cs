using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayGameOverUIModel : GameUIModel
{
    private PlayGameOverUIView view = null;

    public PlayGameOverUIModel()
    {
        view = UnityEngine.Object.FindObjectOfType<PlayGameOverUIView>();

        if (view != null)
        {
            this.Go = view.gameObject;
            this.Name = view.name;
            this.HomeButton = view.homeButton;
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

    private Button homeButton = null;
    public Button HomeButton
    {
        get { return this.homeButton; } 
        set { this.homeButton = value; }
    }

    //////////////////////

    public override void Init()
    {
        HomeButton.onClick.RemoveAllListeners();

        HomeButton.onClick.AddListener(() => ClickHomeButton());

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

    private void ClickHomeButton()
    {
        SoundManager.Instance.EffectPlay(SoundManager.Instance.soundData.uiButtonClickSoundClip, Camera.main.transform.position);

        PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMELOADSTATE);
    }

    public override void UpdateInfo()
    {

    }
}
