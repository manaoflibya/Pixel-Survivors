using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlayState : GameState
{
    public GamePlayState() 
    {

    }


    public override void OnEnter()
    {
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playJoyStickModel);
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.gamePlayUIModel);

        PixelGameManager.Instance.InitCamraController();
        PixelGameManager.Instance.InitMapController();
        PlayerController.Instance.InitPlayerController();
        PixelGameManager.Instance.playTimeContorller.InitPlayerTimeController();

        PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.MOVE);
        SpawnMonsters();
    }

    public override void OnUpdate()
    {
        PixelGameManager.Instance.monsterController.GetMonsterConstant().currentCraeteTime += Time.deltaTime;
        if (PixelGameManager.Instance.monsterController.GetMonsterConstant().currentCraeteTime > PixelGameManager.Instance.monsterController.GetMonsterConstant().createTime && PlayerController.Instance.playerData.PlayerDead.Equals(false))
        {
            PixelGameManager.Instance.monsterController.GetMonsterConstant().currentCraeteTime = 0f;
            SpawnMonsters();

        }

        if (UIPresenter.Instance.FindUseUIModel(UIPresenter.Instance.gamePlayUIModel))
        {
            UIPresenter.Instance.gamePlayUIModel.ChangePlayTimeText(PixelGameManager.Instance.playTimeContorller.GetPlayTime());
        }

        if(PixelGameManager.Instance.playTimeContorller.GetFinishPlayTime())
        {
            PixelGameManager.Instance.ChangePixelGameState(PixelGameManager.PIXELGAMESTATE.GAMESTOPSTATE);

        }
    }

    public override void OnExit()
    {
        PixelGameManager.Instance.playTimeContorller.StopGameTime();

        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playJoyStickModel);
        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.gamePlayUIModel);

        PixelGameManager.Instance.monsterController.DeleteAllMonsters();
        PixelGameManager.Instance.itemController.DeleteAllItems();

        //PixelGameManager.Instance.ClearCameraController();
    }

    private void SpawnMonsters()
    {

        PixelGameManager.Instance.monsterController.OnMonster(
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBatCreateCount,
            OBJECT_TYPE.MONSTERBATTYPE,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBatMaxHealth,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBatDamage,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBatSpeed,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBatSize,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterExpPoint);

        PixelGameManager.Instance.monsterController.OnMonster(
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterSkeletonCreateCount,
            OBJECT_TYPE.MONSTERSKELETONTYPE,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterSkeletonMaxHealth,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterSkeletonDamage,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterSkeletonSpeed,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterSkeletonSize,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterExpPointMiddle); ;

        PixelGameManager.Instance.monsterController.OnMonster(
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterGoblinCreateCount,
            OBJECT_TYPE.MONSTERGOBLINTYPE,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().mosnterGoblinMaxHealth,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterGoblinDamage,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterGoblinSpeed,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterGoblinSize,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterExpPointBIG);

        PixelGameManager.Instance.monsterController.OnMonster(
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBoomberCreateCount, 
            OBJECT_TYPE.MONSTERBOOMBTYPE,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBoomberMaxHealth,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBoomberDamage,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBoomberSpeed,
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterBoomberSize, 
            PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterExpPoint);

        Vector3 vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
        PixelGameManager.Instance.itemController.OnItemGravity(vec);
        vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
        PixelGameManager.Instance.itemController.OnItemBox(vec);
        vec = MapController.Instance.mapData.currentSpawnPoints[Random.Range(0, MapController.Instance.mapData.currentSpawnPoints.Length - 1)].position;
        PixelGameManager.Instance.itemController.OnItemHP(vec, PixelGameManager.Instance.monsterController.GetMonsterConstant().healPoint);

    }
}
