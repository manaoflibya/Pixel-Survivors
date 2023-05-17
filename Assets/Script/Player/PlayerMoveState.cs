using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState() 
    {

    }   

    private PlayerData playerData;


    public override void OnEnter(PlayerData _playerData)
    {
        playerData = _playerData;   
        GameUIModel gameUIModel = UIPresenter.Instance.playJoyStickModel;
        UIPresenter.Instance.UseModelClassList(gameUIModel);

    }

    public override void OnUpdate()
    {
        if(UIPresenter.Instance.playJoyStickModel.Go.activeSelf) 
        {
            Vector3 dirVec = UIPresenter.Instance.playJoyStickModel.MoveVec;
            dirVec.Normalize();

            if(dirVec == Vector3.zero)
            {
                PlayerController.Instance.PlayerAnimationMove(false);
            }
            else
            {
                PlayerController.Instance.PlayerAnimationMove(true);
            }

            PlayerController.Instance.MovePlayerPosition(dirVec);
        }

        //if(Input.GetMouseButtonUp(0)) 
        //{
        //    PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.STOP);
        //}


        //PlayerController.Instance.effectConstant.currentCoolTime += Time.deltaTime;
        //if(PlayerController.Instance.effectConstant.currentCoolTime >= PlayerController.Instance.effectConstant.effectCoolTime)
        //{
        //    if (PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters() != null)
        //    {
        //        PlayerController.Instance.effectController.OnEffectFireBall(
        //            PlayerController.Instance.effectConstant.effectCreateCount,
        //            PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters().transform.position + new Vector3(3f, 10f),
        //            PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters(), // 가까운 몬스터 찾아서 그 위치로 바꿔야함.
        //            PlayerController.Instance.effectConstant.effectFireBallSpeed,
        //            PlayerController.Instance.effectConstant.effectFireBallDamage,
        //            PlayerController.Instance.effectConstant.effectFireBallSize);
        //    }

        //    if (PixelGameManager.Instance.monsterController.FindClosestMonster() != null)
        //    {
        //        PlayerController.Instance.effectController.OnEffectMagicBolt(
        //            PlayerController.Instance.effectConstant.effectCreateCount,
        //            PlayerController.Instance.GetPlayerVec(),
        //            PixelGameManager.Instance.monsterController.FindClosestMonster(),
        //            PlayerController.Instance.effectConstant.effectMagicBoltSpeed,
        //            PlayerController.Instance.effectConstant.effectMagicBoltDamage,
        //            PlayerController.Instance.effectConstant.effectMagicBoltSize);
        //    }

        //    PlayerController.Instance.effectConstant.currentCoolTime = 0f;
        //}

        //PlayerController.Instance.effectConstant.kunaiCurrentCoolTime += Time.deltaTime;
        //if(PlayerController.Instance.effectConstant.kunaiCurrentCoolTime >= PlayerController.Instance.effectConstant.kunaiCoolTime)
        //{
        //    PlayerController.Instance.effectConstant.kunaiCurrentCoolTime = 0f;

        //    PlayerController.Instance.effectController.OnEffectKunai(
        //        PlayerController.Instance.effectConstant.kunaiCreateCount,
        //        PlayerController.Instance.GetPlayerVec(),
        //        PlayerController.Instance.playerData.playerGo.transform,
        //        PlayerController.Instance.effectConstant.effectKunaiAsix,
        //        PlayerController.Instance.effectConstant.effectKunaiAngle,
        //        PlayerController.Instance.effectConstant.effectKunaiSpeed,
        //        PlayerController.Instance.effectConstant.effectKunaiDamage,
        //        PlayerController.Instance.effectConstant.effectKunaiDuration,
        //        PlayerController.Instance.effectConstant.effectKunaiSize);


        //}

        PlayerController.Instance.effectConstant.poisonCurrentCoolTime += Time.deltaTime;
        if(PlayerController.Instance.effectConstant.poisonCurrentCoolTime >= PlayerController.Instance.effectConstant.poisonCoolTime)
        {
            Debug.Log("Poison");
            PlayerController.Instance.effectConstant.poisonCurrentCoolTime = 0f;

            PlayerController.Instance.effectController.OnEffectPoison(
                PlayerController.Instance.effectConstant.poisonCreateCount,
                PlayerController.Instance.GetPlayerVec(),
                PlayerController.Instance.effectConstant.effectPoisondir,
                PlayerController.Instance.effectConstant.effectPoisonAngle,
                PlayerController.Instance.effectConstant.effectPoisonSpeed,
                PlayerController.Instance.effectConstant.effectPoisonDamage,
                PlayerController.Instance.effectConstant.effectPoisonDuration,
                PlayerController.Instance.effectConstant.effectPoisonSize);
        }
    }

    public override void OnExit()
    {
        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playJoyStickModel);
    }
}
