using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public PlayerState()
    {

    }

    public abstract void OnEnter(PlayerData _playerData);

    public abstract void OnUpdate();

    public abstract void OnExit();
}