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

    public PlayerData playerData;

    private PLAYERSTATE currentPlayerState = PLAYERSTATE.NONE;  
    private Dictionary<PLAYERSTATE, PlayerState> playerClassDictionary = new Dictionary<PLAYERSTATE, PlayerState>();     
    

    private void Start()
    {
        InitPlayerController();
    }

    private void Update()
    {
        if(playerClassDictionary.ContainsKey(currentPlayerState))
        {
            playerClassDictionary[currentPlayerState].OnUpdate();
        }
    }

    private void InitPlayerController()
    {
        //처음에는 Begin으로 State를 시작
        ChangePlayerState(PLAYERSTATE.BEGIN);
        
    }

    public void ChangePlayerState(PLAYERSTATE nextState)
    {
        //중복 State 반환
        if(currentPlayerState == nextState) 
            return;
        
        currentPlayerState = nextState;

        if(playerClassDictionary.ContainsKey(currentPlayerState))
        {
            playerClassDictionary[currentPlayerState].OnExit();
        }

        switch(currentPlayerState) 
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
}
