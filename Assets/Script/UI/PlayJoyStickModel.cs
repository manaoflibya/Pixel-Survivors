using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayJoyStickModel : GameUIModel
{
    public PlayJoyStickModel()
    {
        view = UnityEngine.Object.FindObjectOfType<PlayJoyStickView>();

        if(view != null )
        {
            this.Go = view.gameObject;
            this.Name = view.name;
            this.joyStickName = "PixelPlayerJoyStick";
        }
        else
        {
            throw new System.Exception("Check JoyStick UI Model");
        }
    }

    private PlayJoyStickView view = null;
    private string joyStickName = string.Empty;

    public override string Name
    {
        protected set { this.name = value; }
        get { return this.name; }
    }

    public override GameObject Go
    {
        get { return this.go; }
        protected set { this.go = value; }
    }

    private Vector3 moveVec = Vector3.zero;
    public Vector3 MoveVec
    {
        get { return this.moveVec; }
        private set { this.moveVec = value; }  
    }

    public override void Show()
    {
        if (this.go != null)
        {
            this.go.SetActive(true);
        }
        else
        {
            throw new System.Exception("Go is null");
        }
    }

    public override void Hide()
    {
        if(this.go != null) 
        {
            this.go.SetActive(false);
        }
        else
        {
            throw new System.Exception("Go is null");
        }
    }


    public override void Init()
    {
        Hide();
    }


    public override void UpdateInfo()
    {
        this.MoveVec = new Vector3(UltimateJoystick.GetHorizontalAxis(this.joyStickName), UltimateJoystick.GetVerticalAxis(this.joyStickName),0);
    }
}
