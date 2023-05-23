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
            this.ExpBar = view.expBar;
            this.HealthBar = view.healthBar;
            this.PauseButton = view.pauseButton;    
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

    //////////////



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
        //중복으로 콜백에 등록되는 것을 방지.
        PauseButton.onClick.RemoveAllListeners();
        
        PauseButton.onClick.AddListener(()=> ClickPauseButton());

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
        Time.timeScale = 0f;
    }

    public override void UpdateInfo()
    {

    }
}
