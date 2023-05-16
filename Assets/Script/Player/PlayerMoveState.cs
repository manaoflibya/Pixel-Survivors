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

    /// <summary>
    /// ��������.
    /// </summary>
    private float effectCoolTime = 0.5f;
    private float currentCoolTime = 0f;
    private int effectCreateCount = 1;

    private float effectFireBallSpeed = 15f;
    private float effectFireBallDamage = 30f;
    private Vector3 effectFireBallSize = new Vector3(1f, 1f, 0f);

    private float effectMagicBoltSpeed = 5f;
    private float effectMagicBoltDamage = 20f;
    private Vector3 effectMagicBoltSize = new Vector3(2f,2f,0f);
    /// <summary>
    /// </summary>

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

        currentCoolTime += Time.deltaTime;
        if(currentCoolTime >= effectCoolTime)
        {
            if (PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters() == null)
            {
                return;
            }

            PlayerController.Instance.effectController.OnEffectFireBall(
                effectCreateCount,
                PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters().transform.position + new Vector3(3f,10f),
                PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters(), // ����� ���� ã�Ƽ� �� ��ġ�� �ٲ����.
                effectFireBallSpeed,
                effectFireBallDamage,
                effectFireBallSize);

            currentCoolTime = 0f;

            if (PixelGameManager.Instance.monsterController.FindClosestMonster() == null)
            {
                return;
            }

            PlayerController.Instance.effectController.OnEffectMagicBolt(
                effectCreateCount,
                PlayerController.Instance.GetPlayerVec(),
                PixelGameManager.Instance.monsterController.FindClosestMonster(),
                effectMagicBoltSpeed,
                effectMagicBoltDamage,
                effectMagicBoltSize);
        }
    }

    public override void OnExit()
    {
        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playJoyStickModel);
    }
}
