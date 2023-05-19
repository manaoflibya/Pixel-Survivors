using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlayState : GameState
{
    public GamePlayState() 
    {

    }

    private int monsterBatCreateCount = 5;
    //private int monsterGoblinCreateCount = 100;

    // class 따로 만들어야함.
    private float currentCraeteTime = 0f;
    private float createTime = 10f;

    public override void OnEnter()
    {
        //PixelGameManager.Instance.monsterController.OnMonsterBat(monsterBatCreateCount);
        //PixelGameManager.Instance.monsterController.OnMonsterGoblin(monsterBatCreateCount);
        //PixelGameManager.Instance.monsterController.OnMonsterSkeleton(monsterBatCreateCount);
        PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERBOOMBTYPE, 100f, 10f,1.5f ,new Vector3(1f, 1f, 1f));
    }

    public override void OnUpdate()
    {
        currentCraeteTime += Time.deltaTime;   
        if(currentCraeteTime > createTime)
        {
            currentCraeteTime = 0f;
           // PixelGameManager.Instance.monsterController.OnMonsterBat(monsterBatCreateCount);
            //PixelGameManager.Instance.monsterController.OnMonsterGoblin(monsterBatCreateCount);
            //PixelGameManager.Instance.monsterController.OnMonsterSkeleton(monsterBatCreateCount);
        }
    }

    public override void OnExit()
    {

    }
    
}
