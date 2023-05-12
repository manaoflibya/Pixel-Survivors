using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState() 
    {

    }   

    private PlayerData playerData;

    /// <summary>
    /// 지워야함.
    /// </summary>
    private float effectCoolTime = 0.5f;
    private float currentCoolTime = 0f;
    private int effectCreateCount = 1;

    private float effectFireBallSpeed = 15f;
    private float effectFireBallDamage = 50f;
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

        if(Input.GetMouseButtonUp(0)) 
        {
            PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.STOP);
        }

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
                PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters(), // 가까운 몬스터 찾아서 그 위치로 바꿔야함.
                effectFireBallSpeed,
                effectFireBallDamage);
            currentCoolTime = 0f;
        }
    }

    public override void OnExit()
    {
        UIPresenter.Instance.NotUseModelClassList(UIPresenter.Instance.playJoyStickModel);
    }
}
