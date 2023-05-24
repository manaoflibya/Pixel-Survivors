using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoSingleton<PlayerController>
{
    public enum PLAYERSTATE
    {
        NONE,
        BEGIN,
        MOVE,
        STOP,
        END,
    }

    public enum PLAYERATTACK
    {
        NONE,
        ATTACK_1,
        ATTACK_2,
        ATTACK_3,
    }

    public PlayerData playerData;
    public EffectController effectController;
    public EffectConstant effectConstant;

    [SerializeField]
    private PLAYERSTATE currentPlayerState = PLAYERSTATE.NONE;  

    private Dictionary<PLAYERSTATE, PlayerState> playerClassDictionary = new Dictionary<PLAYERSTATE, PlayerState>();
    

    private void Start()
    {
        InitPlayerController();
    }

    private void Update()
    {
        playerData.playerGo.transform.position = GetPlayerVec();
        if(playerClassDictionary.ContainsKey(currentPlayerState) && playerData.checkClassOnExit)
        {
            playerClassDictionary[currentPlayerState].OnUpdate();
        }
    }

    private void InitPlayerController()
    {
        //처음에는 Begin으로 State를 시작
        ChangePlayerState(PLAYERSTATE.BEGIN);
        effectConstant = new EffectConstant();  
        playerData.checkClassOnExit = true;

        //playerData.effects
    }

    public void ChangePlayerState(PLAYERSTATE nextState)
    {
        //중복 State 반환
        if(currentPlayerState == nextState) 
            return;

        if (playerClassDictionary.ContainsKey(currentPlayerState))
        {
            playerClassDictionary[currentPlayerState].OnExit();
        }

        currentPlayerState = nextState;

        switch (currentPlayerState) 
        {
            case PLAYERSTATE.BEGIN:
                {
                    if (!playerClassDictionary.ContainsKey(currentPlayerState))
                    {
                        playerClassDictionary.Add(currentPlayerState, new PlayerBeginState());
                    }
                }
                break;
            case PLAYERSTATE.MOVE:
                {
                    if (!playerClassDictionary.ContainsKey(currentPlayerState))
                    {
                        playerClassDictionary.Add(currentPlayerState, new PlayerMoveState());
                    }
                }
                break;
            case PLAYERSTATE.STOP:
                {
                    if (!playerClassDictionary.ContainsKey(currentPlayerState))
                    {
                        playerClassDictionary.Add(currentPlayerState, new PlayerStopState());
                    }
                }
                break;
            case PLAYERSTATE.END:
                {
                    if (!playerClassDictionary.ContainsKey(currentPlayerState))
                    {
                        playerClassDictionary.Add(currentPlayerState, new PlayerEndState());
                    }
                }
                break; 
        }

        if (playerClassDictionary[currentPlayerState] != null)
        {
            playerClassDictionary[currentPlayerState].OnEnter(playerData);
        }
    }

    public void SetAllowMove(bool isAllow)
    {
        playerData.AllowMove = isAllow;
    }

    public void MovePlayerPosition(Vector3 moveVec)
    {
        GetPlayerObject().transform.Translate(moveVec * Time.deltaTime * playerData.Speed);

        if (moveVec.x > 0)
        {
            playerData.scaleGo.transform.localScale = new Vector3(-playerData.playerSize, playerData.playerSize, playerData.playerSize);
        }
        else if (moveVec.x < 0)
        {
            playerData.scaleGo.transform.localScale = new Vector3(playerData.playerSize, playerData.playerSize, playerData.playerSize);
        }
    }

    public void PlayerAnimationMove(bool isMove)
    {
        playerData.playerAnimator.SetBool(playerData.playerWalkAnimationName, isMove);
    }

    public void TakeDamage(float damage)
    {
        if(playerData.Health <= 0)
        {
            return;
        }

        playerData.Health -= damage;

        if(playerData.Health < 0)
        {
            playerData.PlayerDead = true;
        }

        if (UIPresenter.Instance.FindUseUIModel(UIPresenter.Instance.gamePlayUIModel))
        {
            UIPresenter.Instance.gamePlayUIModel.HealthBarChange(playerData.MaxHealth, playerData.Health);
        }

        Debug.Log("current Player Health "+ playerData.Health);
    }

    public void TakeHeal(float heal)
    {
        if(playerData.PlayerDead.Equals(true))
        {
            return;
        }

        playerData.Health += heal;
        
        if(playerData.Health > playerData.MaxHealth)
        {
            playerData.Health = playerData.MaxHealth;
        }

        if(UIPresenter.Instance.FindUseUIModel(UIPresenter.Instance.gamePlayUIModel))
        {
            UIPresenter.Instance.gamePlayUIModel.HealthBarChange(playerData.MaxHealth, playerData.Health);
        }

        Debug.Log("current Player Health " + playerData.Health);
    }

    public Vector3 GetPlayerVec()
    {
        return playerData.transform.position;
    }

    public GameObject GetPlayerObject()
    {
        return playerData.gameObject;
    }

    public void PlayerDeadAnim()
    {
        playerData.playerAnimator.SetTrigger(playerData.playerDeadAnimationName);
    }

    public void TakeEXP(float exp)
    {
        float residual = 0f;

        playerData.PlayerEXP += exp;

        if(playerData.PlayerEXP >= playerData.PlayerMaxEXP)
        {
            Debug.Log("Player Level UP!(Please Add Method here)");
            residual = playerData.PlayerEXP - playerData.PlayerMaxEXP;
            playerData.PlayerEXP = 0f;
            playerData.PlayerMaxEXP += playerData.expIncreaseValue;
            PlayerLevelUp();
        }

        playerData.PlayerEXP += residual;

        if(UIPresenter.Instance.FindUseUIModel(UIPresenter.Instance.gamePlayUIModel))
        {
            UIPresenter.Instance.gamePlayUIModel.ExpBarChange(playerData.PlayerMaxEXP, playerData.PlayerEXP);
        }    
    }

    private void PlayerLevelUp()
    {
        Sprite effectSprite = null;

        int levelupType = UnityEngine.Random.Range((int)OBJECT_TYPE.EFFECTFIREBALLTYPE, (int)OBJECT_TYPE.EFFECTBATMANTYPE);

        switch((OBJECT_TYPE)levelupType)
        {
            case OBJECT_TYPE.EFFECTFIREBALLTYPE:
                {
                    effectSprite = playerData.effectFireBallSprite;
                    effectConstant.fireBallUpgradeCount++;
                }
                break;
            case OBJECT_TYPE.EFFECTMAGICBOLTTYPE:
                {
                    effectSprite = playerData.effectMagicBoltSprite;
                    effectConstant.magicBoltUpgradeCount++;
                }
                break;
            case OBJECT_TYPE.EFFECTKUNAITYPE:
                {
                    effectSprite = playerData.effectKunaiSprite;
                    effectConstant.kunaiUpgradeCount++;
                }
                break;
            case OBJECT_TYPE.EFFECTPOISONTYPE:
                {
                    effectSprite = playerData.effectPoisonSprite;
                    effectConstant.poisonUpgradeCount++;
                }
                break;
            case OBJECT_TYPE.EFFECTBOUNCEBALLTYPE:
                {
                    effectSprite = playerData.effectBounceBallSprite;
                    effectConstant.bounceBallUpgradeCount++;    
                }
                break;
            case OBJECT_TYPE.EFFECTBATMANTYPE:
                {
                    effectSprite = playerData.effectBatManSprite;
                    effectConstant.batManUpgradeCount++;
                }
                break;

        }

        UIPresenter.Instance.UseModelClassList(UIPresenter.Instance.playLevelUpUIModel);
        if(UIPresenter.Instance.FindUseUIModel(UIPresenter.Instance.playLevelUpUIModel) && effectSprite != null)
        {
            UIPresenter.Instance.playLevelUpUIModel.ChangePlayerEffectImage(effectSprite);
        }
    }
}
