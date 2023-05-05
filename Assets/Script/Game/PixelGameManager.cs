using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PixelGameManager : MonoSingleton<PixelGameManager>
{
    public enum PIXELGAMESTATE
    {
        NONE,
        GAMESPLASHSTATE,
        GAMEMUNUSTATE,
        GAMELOADSTATE,
        GAMEPLAYSTATE,
        GAMESTOPSTATE,
        GAMESCORESTATE,
        GAMESHOPSTATE,
    }

    public PIXELGAMESTATE currentGameState = PIXELGAMESTATE.NONE;
    private Dictionary<PIXELGAMESTATE, GameState> gameStateDictionary = new Dictionary<PIXELGAMESTATE, GameState>();
   // private GameState gameState;

    private void Start()
    {
        PixelGameManagerInit();
    }

    private void PixelGameManagerInit()
    {
        ChangePixelGameState(PIXELGAMESTATE.GAMEPLAYSTATE); // ¹Ù²ã¾ßÇÔ
    }

    private void Update()
    {
        if(gameStateDictionary.ContainsKey(currentGameState))
        {
            gameStateDictionary[currentGameState].OnUpdate();
        }
    }

    public void ChangePixelGameState(PIXELGAMESTATE state)
    {
        if (currentGameState == state)
            return;

        
        if(gameStateDictionary.ContainsKey(currentGameState))
        {
            gameStateDictionary[currentGameState].OnExit();
        }

        currentGameState = state;

        switch (currentGameState)
        {
            case PIXELGAMESTATE.GAMESPLASHSTATE:
                {

                }
                break;
            case PIXELGAMESTATE.GAMEMUNUSTATE:
                {

                }
                break;
            case PIXELGAMESTATE.GAMELOADSTATE:
                {

                }
                break;
            case PIXELGAMESTATE.GAMEPLAYSTATE:
                {
                    if (!gameStateDictionary.ContainsKey(currentGameState))
                    {
                        gameStateDictionary.Add(currentGameState, new GamePlayState());
                    }
                }
                break;
            case PIXELGAMESTATE.GAMESTOPSTATE:
                {
                    if (!gameStateDictionary.ContainsKey(currentGameState))
                    {
                        gameStateDictionary.Add(currentGameState, new GameStopState());
                    }
                }
                break;

            case PIXELGAMESTATE.GAMESCORESTATE:
                {

                }
                break;
            case PIXELGAMESTATE.GAMESHOPSTATE:
                {

                }
                break;
        }

        if (gameStateDictionary.ContainsKey(currentGameState)) 
        {
            gameStateDictionary[currentGameState].OnEnter();
        }
    }
}
