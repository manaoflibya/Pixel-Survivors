using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIModel : GameUIModel
{
    private GamePlayUIView view = null;

    public GamePlayUIModel()
    {
        view = UnityEngine.Object.FindObjectOfType<GamePlayUIView>();

        if(view != null)
        {
            this.Go = view.gameObject;
            this.Name = view.name;
            this.HitImage = view.hitImage;
            this.ExpBar = view.expBar;
            this.HealthBar = view.healthBar;
            this.PauseButton = view.pauseButton;    
            this.PlayTimeText = view.playTimeText;
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

    public float Timer = 0f;
    private float timer
    {
        get { return this.timer; }
        set { this.timer = value; }
    }

    private Image hitImage = null;
    public Image HitImage
    {
        set { this.hitImage = value; }
        get { return this.hitImage; }
    }

    private Slider expBar = null;
    public Slider ExpBar
    {
        set { this.expBar = value; }
        get { return this.expBar; }
    }

    private Slider healthBar = null;
    public Slider HealthBar
    {
        set { this.healthBar = value; }
        get { return this.healthBar; }
    }

    private Button pauseButton = null;
    public Button PauseButton
    {
        set { this.pauseButton = value; }
        get { return this.pauseButton; }
    }
        
    private Text playTimeText = null;
    public Text PlayTimeText
    {
        set { this.playTimeText = value; }
        get { return this.playTimeText; }
    }

    //////////////



    public override void Hide()
    {
        if (this.Go != null)
        {
            this.Go.SetActive(false);
            HitImage.gameObject.SetActive(false);
        }
        else
        {
            throw new System.Exception("Go is null");
        }
    }

    public override void Init()
    {
        //중복으로 콜백에 등록되는 것을 방지.
        PauseButton.onClick.RemoveAllListeners();
        
        PauseButton.onClick.AddListener(()=> ClickPauseButton());

        // 타이머 초기화
        Timer = 0f;

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

    public void OnHitImage()
    {
        //HitImage.gameObject.SetActive(true);
    }

    public void OffHItImage()
    {
        //HitImage.gameObject.SetActive(false);
    }

    public void HealthBarChange(float maxHealth ,float value)
    {
        HealthBar.maxValue = maxHealth;
        HealthBar.value = value;
    }

    public void ExpBarChange(float max, float value)
    {
        ExpBar.maxValue = max;
        ExpBar.value = value;
    }

    public void ClickPauseButton()
    {
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playSettingUIModel);
    }


    public void ChangePlayTimeText(string timeText)
    {
        PlayTimeText.text = timeText;
    }

    public override void UpdateInfo()
    {
    }
}
