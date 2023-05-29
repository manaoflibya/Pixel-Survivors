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

        PlayerController.Instance.effectController.GetEffectConstant().currentCoolTime += Time.deltaTime;
        if (PlayerController.Instance.effectController.GetEffectConstant().currentCoolTime >= PlayerController.Instance.effectController.GetEffectConstant().effectCoolTime)
        {
            if (PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters() != null)
            {
                PlayerController.Instance.effectController.OnEffectFireBall(
                    PlayerController.Instance.effectController.GetEffectConstant().effectCreateCount,
                    PlayerController.Instance.effectController.GetEffectConstant().fireBallUpgradeCount,
                    PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters().transform.position + new Vector3(3f, 10f),
                    PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters(), // 가까운 몬스터 찾아서 그 위치로 바꿔야함.
                    PlayerController.Instance.effectController.GetEffectConstant().effectFireBallSpeed,
                    PlayerController.Instance.effectController.GetEffectConstant().effectFireBallDamage,
                    PlayerController.Instance.effectController.GetEffectConstant().effectFireBallSize);
            }

            if (PixelGameManager.Instance.monsterController.FindClosestMonster() != null)
            {
                PlayerController.Instance.effectController.OnEffectMagicBolt(
                    PlayerController.Instance.effectController.GetEffectConstant().effectCreateCount,
                    PlayerController.Instance.effectController.GetEffectConstant().magicBoltUpgradeCount,
                    PlayerController.Instance.GetPlayerVec(),
                    PixelGameManager.Instance.monsterController.FindClosestMonster(),
                    PlayerController.Instance.effectController.GetEffectConstant().effectMagicBoltSpeed,
                    PlayerController.Instance.effectController.GetEffectConstant().effectMagicBoltDamage,
                    PlayerController.Instance.effectController.GetEffectConstant().effectMagicBoltSize);
            }

            PlayerController.Instance.effectController.GetEffectConstant().currentCoolTime = 0f;
        }

        PlayerController.Instance.effectController.GetEffectConstant().kunaiCurrentCoolTime += Time.deltaTime;
        if (PlayerController.Instance.effectController.GetEffectConstant().kunaiCurrentCoolTime >= PlayerController.Instance.effectController.GetEffectConstant().kunaiCoolTime)
        {
            PlayerController.Instance.effectController.GetEffectConstant().kunaiCurrentCoolTime = 0f;

            PlayerController.Instance.effectController.OnEffectKunai(
                PlayerController.Instance.effectController.GetEffectConstant().kunaiCreateCount,
                PlayerController.Instance.effectController.GetEffectConstant().kunaiUpgradeCount,
                PlayerController.Instance.GetPlayerVec(),
                PlayerController.Instance.playerData.playerGo.transform,
                PlayerController.Instance.effectController.GetEffectConstant().effectKunaiAsix,
                PlayerController.Instance.effectController.GetEffectConstant().effectKunaiAngle,
                PlayerController.Instance.effectController.GetEffectConstant().effectKunaiSpeed,
                PlayerController.Instance.effectController.GetEffectConstant().effectKunaiDamage,
                PlayerController.Instance.effectController.GetEffectConstant().effectKunaiDuration,
                PlayerController.Instance.effectController.GetEffectConstant().effectKunaiSize);
        }

        PlayerController.Instance.effectController.GetEffectConstant().poisonCurrentCoolTime += Time.deltaTime;

        if (PlayerController.Instance.effectController.GetEffectConstant().poisonCurrentCoolTime >= PlayerController.Instance.effectController.GetEffectConstant().poisonCoolTime)
        {
            PlayerController.Instance.effectController.GetEffectConstant().poisonCurrentCoolTime = 0f;

            PlayerController.Instance.effectController.OnEffectPoison(
                PlayerController.Instance.effectController.GetEffectConstant().poisonCreateCount,
                PlayerController.Instance.effectController.GetEffectConstant().poisonUpgradeCount,
                PlayerController.Instance.GetPlayerVec(),
                PlayerController.Instance.effectController.GetEffectConstant().effectPoisondir,
                PlayerController.Instance.effectController.GetEffectConstant().effectPoisonAngle,
                PlayerController.Instance.effectController.GetEffectConstant().effectPoisonSpeed,
                PlayerController.Instance.effectController.GetEffectConstant().effectPoisonDamage,
                PlayerController.Instance.effectController.GetEffectConstant().effectPoisonDuration,
                PlayerController.Instance.effectController.GetEffectConstant().effectPoisonSize);
        }

        PlayerController.Instance.effectController.GetEffectConstant().bounceBallCurrentCoolTime += Time.deltaTime;

        if (PlayerController.Instance.effectController.GetEffectConstant().bounceBallCurrentCoolTime >= PlayerController.Instance.effectController.GetEffectConstant().bounceBallCoolTime)
        {
            PlayerController.Instance.effectController.GetEffectConstant().bounceBallCurrentCoolTime = 0f;
            PlayerController.Instance.effectController.OnEffectBounceBall(
                PlayerController.Instance.effectController.GetEffectConstant().bounceCreateCount,
                PlayerController.Instance.effectController.GetEffectConstant().bounceBallUpgradeCount,
                PlayerController.Instance.GetPlayerVec(),
                PixelGameManager.Instance.monsterController.FindClosestMonster(),
                PlayerController.Instance.effectController.GetEffectConstant().effectBounceBallSpeed,
                PlayerController.Instance.effectController.GetEffectConstant().effectBounceBallDamage,
                PlayerController.Instance.effectController.GetEffectConstant().effectBounceBallDuration,
                PlayerController.Instance.effectController.GetEffectConstant().effectBounceBallSize);
        }

        PlayerController.Instance.effectController.GetEffectConstant().batManCurrentCoolTime += Time.deltaTime;

        if (PlayerController.Instance.effectController.GetEffectConstant().batManCurrentCoolTime >= PlayerController.Instance.effectController.GetEffectConstant().batmanCoolTime)
        {
            PlayerController.Instance.effectController.GetEffectConstant().batManCurrentCoolTime = 0f;

            Vector3 effectBatmanDir = new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));

            PlayerController.Instance.effectController.OnEffectBatMan(
                PlayerController.Instance.effectController.GetEffectConstant().batManCreateCount,
                PlayerController.Instance.effectController.GetEffectConstant().batManUpgradeCount,
                PlayerController.Instance.GetPlayerVec(),
                effectBatmanDir.normalized,
                PlayerController.Instance.effectController.GetEffectConstant().batManHitCount,
                PlayerController.Instance.effectController.GetEffectConstant().effectBatManSpeed,
                PlayerController.Instance.effectController.GetEffectConstant().effectBatManDamage,
                PlayerController.Instance.effectController.GetEffectConstant().effectBatManSize);
        }
    }

    public override void OnExit()
    {
    }
}
