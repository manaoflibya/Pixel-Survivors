using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayLevelUpUIModel : GameUIModel
{

    private PlayLevelUpUIView view = null;


    public PlayLevelUpUIModel()
    {
        view = UnityEngine.Object.FindObjectOfType<PlayLevelUpUIView>();

        if (view != null)
        {
            this.Go = view.gameObject;
            this.Name = view.name;
            this.PlayButton = view.playButton;
            this.StartButton = view.startButton;
            this.LevelupBoxImage = view.levelupBoxImage;
            this.PlayerEffectImage = view.playerEffectImage;
            this.LaserImage = view.laserImage;
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

    private Button startButton = null;
    public Button StartButton
    {
        get { return this.startButton; }
        set { this.startButton = value; }
    }

    private Image levelupBoxImage = null;
    public Image LevelupBoxImage
    {
        get { return this.levelupBoxImage; }
        set { this.levelupBoxImage = value; }
    }

    private Image playerEffectImage = null;
    public Image PlayerEffectImage
    {
        get { return this.playerEffectImage; }
        set { this.playerEffectImage = value; }
    }

    private Image laserImage = null;
    public Image LaserImage
    {
        get { return this.laserImage; }
        set { this.laserImage = value; }
    }

    ////////////////
    
    public override void Init()
    {
        Hide();
    }

    public override void Hide()
    {
        if (this.Go != null)
        {
            this.Go.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            throw new System.Exception("Go is null");
        }
    }


    public override void Show()
    {
        if (this.Go != null)
        {
            this.Go.SetActive(true);

            PlayButton.onClick.RemoveAllListeners();
            StartButton.onClick.RemoveAllListeners(); 

            PlayButton.onClick.AddListener(()=> ClickPlayButton());
            StartButton.onClick.AddListener(()=> ClickStartButton());


            Time.timeScale = 0f;
            ShowActives();
        }
        else
        {
            throw new System.Exception("Go is null");
        }
    }

    private void ShowActives()
    {
        PlayButton.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(true);
        LevelupBoxImage.gameObject.SetActive(true);
        playerEffectImage.gameObject.SetActive(false);
        LaserImage.gameObject.SetActive(false);
    }

    private void ClickPlayButton()
    {
        UIPresenter.Instance.NotUseModelClassList(this);
    }

    public void ChangePlayerEffectImage(Sprite effectImage)
    {
        PlayerEffectImage.sprite = effectImage;
    }

    private void ClickStartButton()
    {
        PlayButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        LevelupBoxImage.gameObject.SetActive(false);
        playerEffectImage.gameObject.SetActive(true);
        LaserImage.gameObject.SetActive(true);
    }

    public override void UpdateInfo()
    {

    }
}
