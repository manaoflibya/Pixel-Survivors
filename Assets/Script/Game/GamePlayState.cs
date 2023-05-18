using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameState
{
    public GamePlayState() 
    {

    }

    private int monsterBatCreateCount = 30;
    private int monsterGoblinCreateCount = 100;

    public override void OnEnter()
    {
        PixelGameManager.Instance.monsterController.OnMonsterBat(monsterBatCreateCount);
        PixelGameManager.Instance.monsterController.OnMonsterGoblin(monsterBatCreateCount);

    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
    
}
