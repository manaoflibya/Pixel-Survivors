using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameWinUIModel : GameUIModel
{
    private PlayGameWinUIView view = null;

    public PlayGameWinUIModel()
    {
        view = UnityEngine.Object.FindObjectOfType<PlayGameWinUIView>();

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
        Debug.Log("Need Method ClickHomeButton");
    }

    public override void UpdateInfo()
    {

    }
}
