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

    private PLAYERSTATE myState = PLAYERSTATE.NONE;  
    private PlayerState currentState;
    private Dictionary<PLAYERSTATE, PlayerState> playerClassDictionary = new Dictionary<PLAYERSTATE, PlayerState>();     
    

    private void Start()
    {
        InitPlayerController();
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    private void InitPlayerController()
    {
        if(playerData != null)
        {
            SetAllowMove(false);        
        }

        //처음에는 Begin으로 State를 시작
        ChangePlayerState(PLAYERSTATE.BEGIN);
        
    }

    public void ChangePlayerState(PLAYERSTATE nextState)
    {
        //중복 State 반환
        if(myState == nextState) 
            return;
        
        myState = nextState;

        if(currentState != null)
            currentState.OnExit();

        switch(myState) 
        {
            case PLAYERSTATE.BEGIN:
                {
                    if (!playerClassDictionary.ContainsKey(myState))
                    {
                        playerClassDictionary.Add(myState, new PlayerBeginState());
                    }

                    currentState = playerClassDictionary[myState];
                }
                break;
            case PLAYERSTATE.MOVE:
                {
                    if (!playerClassDictionary.ContainsKey(myState))
                    {
                        playerClassDictionary.Add(myState, new PlayerMoveState());
                    }

                    currentState = playerClassDictionary[myState];
                }
                break;
            case PLAYERSTATE.STOP:
                {
                    if (!playerClassDictionary.ContainsKey(myState))
                    {
                        playerClassDictionary.Add(myState, new PlayerStopState());
                    }

                    currentState = playerClassDictionary[myState];

                }
                break;
            case PLAYERSTATE.END:
                {
                    if (!playerClassDictionary.ContainsKey(myState))
                    {
                        playerClassDictionary.Add(myState, new PlayerEndState());
                    }

                    currentState = playerClassDictionary[myState];

                }
                break; 
        }

        if (currentState != null && currentState != null)
        {
            currentState.OnEnter(playerData);
        }
    }

    public void SetAllowMove(bool isAllow)
    {
        playerData.allowMove = isAllow;
    }
}
