using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    public GamePlayState() 
    {

    }

    private int monsterBatCreateCount = 30;

    public override void OnEnter()
    {
        PixelGameManager.Instance.monsterController.OnSetMonsterBat(monsterBatCreateCount);

    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
    
}
