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
        GAMEMENUSTATE,
        GAMELOADSTATE,
        GAMEPLAYSTATE,
        GAMESTOPSTATE,
        GAMESCORESTATE,
        GAMESHOPSTATE,
    }

    public PIXELGAMESTATE currentGameState = PIXELGAMESTATE.NONE;
    private Dictionary<PIXELGAMESTATE, GameState> gameStateDictionary = new Dictionary<PIXELGAMESTATE, GameState>();

    public MonsterController monsterController;
    public ItemController itemController;
    public PlayTimeController playTimeContorller;
    public SceneContoller sceneController;

    public MapController mapController;
    public CameraController cameraController;

    private void Start()
    {
        PixelGameManagerInit();
    }

    private void PixelGameManagerInit()
    {
        ChangePixelGameState(PIXELGAMESTATE.GAMEMENUSTATE); 
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void InitCamraController()
    {
        cameraController = FindObjectOfType<CameraController>();
        
        if(cameraController != null)
        {
            cameraController.InitCameraController();
        }
    }

    public void InitMapController()
    {
        mapController = FindObjectOfType<MapController>();  

        if(mapController != null)
        {
            mapController.InitMapController();
        }
    }

    public void ClearCameraController()
    {
        cameraController = null;
    }

    public void ClearMapController()
    {
        mapController = null;
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
            case PIXELGAMESTATE.GAMEMENUSTATE:
                {
                    if (!gameStateDictionary.ContainsKey(currentGameState))
                    {
                        gameStateDictionary.Add(currentGameState, new GameMenuState());
                    }

                }
                break;
            case PIXELGAMESTATE.GAMELOADSTATE:
                {
                    if (!gameStateDictionary.ContainsKey(currentGameState))
                    {
                        gameStateDictionary.Add(currentGameState, new GameLoadState());
                    }
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
