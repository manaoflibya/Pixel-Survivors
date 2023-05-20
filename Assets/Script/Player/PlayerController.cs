using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
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
        playerData.playerGo.transform.Translate(moveVec * Time.deltaTime * playerData.Speed);

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
        if(playerData.PlayerDead.Equals(false))
        {
            playerData.playerAnimator.SetBool(playerData.playerWalkAnimationName, isMove);
        }
    }

    public void TakeDamage(float damage)
    {
        playerData.Health -= damage;
        Debug.Log("current Player Health "+ playerData.Health);
    }

    public Vector3 GetPlayerVec()
    {
        return playerData.transform.position;
    }

    public void PlayerDeadAnim()
    {
        playerData.playerAnimator.SetTrigger(playerData.playerDeadAnimationName);
    }
}
