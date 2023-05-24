using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUIModel
{
    public abstract string Name { get; protected set; }
    protected string name;

    public abstract UnityEngine.GameObject Go { get; protected set; }
    protected UnityEngine.GameObject go;

    public abstract void Init();

    public abstract void Show();

    public abstract void Hide();

    public abstract void UpdateInfo();
}
