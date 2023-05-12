using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopState : PlayerState
{
    public PlayerStopState()
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
    private float effectFireBallDamage = 50f;
    /// <summary>
    /// </summary>


    public override void OnEnter(PlayerData _playerData)
    {
        playerData = _playerData;

            
        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playJoyStickModel);
        PlayerController.Instance.PlayerAnimationMove(false);
    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController.Instance.ChangePlayerState(PlayerController.PLAYERSTATE.MOVE);
        }


        currentCoolTime += Time.deltaTime;
        if (currentCoolTime >= effectCoolTime)
        {
            if (PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters() == null)
            {
                return;
            }


            PlayerController.Instance.effectController.OnEffectFireBall(
                effectCreateCount,
                PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters().transform.position + new Vector3(3f, 10f),
                PixelGameManager.Instance.monsterController.FindCameraVisibleMonsters(), // ����� ���� ã�Ƽ� �� ��ġ�� �ٲ����.
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
