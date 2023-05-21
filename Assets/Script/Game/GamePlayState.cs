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
    private float monsterExpPoint = 10f;
    private float monsterExpPointMiddle = 30f;
    private float monsterExpPointBIG = 50f;
    private float createTime = 10f;

    private float healPoint = 5f;

    public override void OnEnter()
    {
        PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERBOOMBTYPE, 100f, 1f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPoint);
        PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERBATTYPE, 100f, 1f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPointMiddle);
        PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERBOOMBTYPE, 100f, 1f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPointBIG);
        PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERSKELETONTYPE, 100f, 1f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPoint);
        
        Vector3 vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
        PixelGameManager.Instance.itemController.OnItemGravity(vec);
        vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
        PixelGameManager.Instance.itemController.OnItemBox(vec);
        vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
        PixelGameManager.Instance.itemController.OnItemHP(vec, healPoint);

    }

    public override void OnUpdate()
    {
        currentCraeteTime += Time.deltaTime;   
        if(currentCraeteTime > createTime && PlayerController.Instance.playerData.PlayerDead.Equals(false))
        {
            currentCraeteTime = 0f;
            PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERBOOMBTYPE, 100f, 10f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPoint);
            PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERBATTYPE, 100f, 10f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPointMiddle);
            PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERBOOMBTYPE, 100f, 10f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPointBIG);
            PixelGameManager.Instance.monsterController.OnMonster(monsterBatCreateCount, OBJECT_TYPE.MONSTERSKELETONTYPE, 100f, 10f, 1.5f, new Vector3(1f, 1f, 1f), monsterExpPoint);

            Vector3 vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
            PixelGameManager.Instance.itemController.OnItemGravity(vec);
            vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
            PixelGameManager.Instance.itemController.OnItemBox(vec);
            vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
            PixelGameManager.Instance.itemController.OnItemHP(vec, healPoint);

        }
    }

    public override void OnExit()
    {

    }
    
}
