using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUIModel : GameUIModel
{
    private LoadUIView view = null;

    public LoadUIModel()
    {
        view = UnityEngine.Object.FindObjectOfType<LoadUIView>();

        if (view != null)
        {
            this.Go = view.gameObject;
            this.Name = view.name;
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

    //////////////////////

    public override void Init()
    {
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

    public override void UpdateInfo()
    {

    }
}
