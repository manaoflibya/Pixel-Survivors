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
    }

    public override void OnUpdate()
    {
        if (PlayerController.Instance.playerData.PlayerDead.Equals(true))
        {
            PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.END);
            return;
        }

        if (UIPresenter.Instance.playJoyStickModel.Go.activeSelf) 
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


        PlayerController.Instance.effectConstant.currentCoolTime += Time.deltaTime;
        if (PlayerController.Instance.effectConstant.currentCoolTime >= PlayerController.Instance.effectConstant.effectCoolTime)
        {
            if (PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters() != null)
            {
                PlayerController.Instance.effectController.OnEffectFireBall(
                    PlayerController.Instance.effectConstant.effectCreateCount,
                    PlayerController.Instance.effectConstant.fireBallUpgradeCount,
                    PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters().transform.position + new Vector3(3f, 10f),
                    PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters(), // 가까운 몬스터 찾아서 그 위치로 바꿔야함.
                    PlayerController.Instance.effectConstant.effectFireBallSpeed,
                    PlayerController.Instance.effectConstant.effectFireBallDamage,
                    PlayerController.Instance.effectConstant.effectFireBallSize);
            }
            Debug.Log("Create FireBall!");
            //if (PixelGameManager.Instance.monsterController.FindClosestMonster() != null)
            //{
            //    PlayerController.Instance.effectController.OnEffectMagicBolt(
            //        PlayerController.Instance.effectConstant.effectCreateCount,
            //        PlayerController.Instance.effectConstant.magicBoltUpgradeCount,
            //        PlayerController.Instance.GetPlayerVec(),
            //        PixelGameManager.Instance.monsterController.FindClosestMonster(),
            //        PlayerController.Instance.effectConstant.effectMagicBoltSpeed,
            //        PlayerController.Instance.effectConstant.effectMagicBoltDamage,
            //        PlayerController.Instance.effectConstant.effectMagicBoltSize);
            //}

            PlayerController.Instance.effectConstant.currentCoolTime = 0f;
        }

        //PlayerController.Instance.effectConstant.kunaiCurrentCoolTime += Time.deltaTime;
        //if (PlayerController.Instance.effectConstant.kunaiCurrentCoolTime >= PlayerController.Instance.effectConstant.kunaiCoolTime)
        //{
        //    PlayerController.Instance.effectConstant.kunaiCurrentCoolTime = 0f;

        //    PlayerController.Instance.effectController.OnEffectKunai(
        //        PlayerController.Instance.effectConstant.kunaiCreateCount,
        //        PlayerController.Instance.effectConstant.kunaiUpgradeCount,
        //        PlayerController.Instance.GetPlayerVec(),
        //        PlayerController.Instance.playerData.playerGo.transform,
        //        PlayerController.Instance.effectConstant.effectKunaiAsix,
        //        PlayerController.Instance.effectConstant.effectKunaiAngle,
        //        PlayerController.Instance.effectConstant.effectKunaiSpeed,
        //        PlayerController.Instance.effectConstant.effectKunaiDamage,
        //        PlayerController.Instance.effectConstant.effectKunaiDuration,
        //        PlayerController.Instance.effectConstant.effectKunaiSize);


        //}

        //PlayerController.Instance.effectConstant.poisonCurrentCoolTime += Time.deltaTime;
        //if (PlayerController.Instance.effectConstant.poisonCurrentCoolTime >= PlayerController.Instance.effectConstant.poisonCoolTime)
        //{
        //    PlayerController.Instance.effectConstant.poisonCurrentCoolTime = 0f;

        //    PlayerController.Instance.effectController.OnEffectPoison(
        //        PlayerController.Instance.effectConstant.poisonCreateCount,
        //        PlayerController.Instance.effectConstant.poisonUpgradeCount,
        //        PlayerController.Instance.GetPlayerVec(),
        //        PlayerController.Instance.effectConstant.effectPoisondir,
        //        PlayerController.Instance.effectConstant.effectPoisonAngle,
        //        PlayerController.Instance.effectConstant.effectPoisonSpeed,
        //        PlayerController.Instance.effectConstant.effectPoisonDamage,
        //        PlayerController.Instance.effectConstant.effectPoisonDuration,
        //        PlayerController.Instance.effectConstant.effectPoisonSize);
        //}

        //PlayerController.Instance.effectConstant.bounceBallCurrentCoolTime += Time.deltaTime;
        //if (PlayerController.Instance.effectConstant.bounceBallCurrentCoolTime >= PlayerController.Instance.effectConstant.bounceBallCoolTime)
        //{
        //    PlayerController.Instance.effectConstant.bounceBallCurrentCoolTime = 0f;
        //    PlayerController.Instance.effectController.OnEffectBounceBall(
        //        PlayerController.Instance.effectConstant.bounceCreateCount,
        //        PlayerController.Instance.effectConstant.bounceBallUpgradeCount,
        //        PlayerController.Instance.GetPlayerVec(),
        //        PixelGameManager.Instance.monsterController.FindClosestMonster(),
        //        PlayerController.Instance.effectConstant.effectBounceBallSpeed,
        //        PlayerController.Instance.effectConstant.effectBounceBallDamage,
        //        PlayerController.Instance.effectConstant.effectBounceBallDuration,
        //        PlayerController.Instance.effectConstant.effectBounceBallSize);
        //}

        //PlayerController.Instance.effectConstant.batManCurrentCoolTime += Time.deltaTime;
        //if (PlayerController.Instance.effectConstant.batManCurrentCoolTime >= PlayerController.Instance.effectConstant.batmanCoolTime)
        //{
        //    PlayerController.Instance.effectConstant.batManCurrentCoolTime = 0f;

        //    Vector3 effectBatmanDir = new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));

        //    PlayerController.Instance.effectController.OnEffectBatMan(
        //        PlayerController.Instance.effectConstant.batManCreateCount,
        //        PlayerController.Instance.effectConstant.batManUpgradeCount,
        //        PlayerController.Instance.GetPlayerVec(),
        //        effectBatmanDir.normalized,
        //        PlayerController.Instance.effectConstant.batManHitCount,
        //        PlayerController.Instance.effectConstant.effectBatManSpeed,
        //        PlayerController.Instance.effectConstant.effectBatManDamage,
        //        PlayerController.Instance.effectConstant.effectBatManSize);
        //}

    }

    public override void OnExit()
    {
    }
}
