using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayTimeController : MonoBehaviour
{
    private PlayTimeData playTimeData;
    private PlayTimeConstant constant;

    private void Start()
    {
        playTimeData = new PlayTimeData();
        constant = new PlayTimeConstant();
        
        Init();
    }

    private void FixedUpdate()
    {
        if(playTimeData.isPlaying.Equals(true) && playTimeData.currentTime < constant.maxTime)
        {
            playTimeData.currentTime += Time.fixedDeltaTime;
        }
        else
        {
            StopGameTime();
            playTimeData.isFinishPlayTime = true;  
            playTimeData.currentTime = constant.maxTime;
        }
    }

    private void Init()
    {
        playTimeData.maxTime = constant.maxTime;
        playTimeData.currentTime = constant.initCurrentTime;
        playTimeData.isPlaying = false;
        playTimeData.isFinishPlayTime = false;
    }

    public void StartGameTime()
    {
        playTimeData.isPlaying = true;
    }
    
    public void StopGameTime()
    {
        playTimeData.isPlaying = false;
    }

    public string GetPlayTime()
    {
        string getString = string.Empty;

        int second = (int)playTimeData.currentTime % 60;
        string minute = ((int)playTimeData.currentTime / 60 % 60).ToString();

        if (second < 10)
        {
            getString  = string.Format("0{0}:0{1}", minute, second.ToString());
        }
        else
        {
            getString = string.Format("0{0}:{1}", minute, second.ToString());
        }

        return getString;
    }

    public bool GetFinishPlayTime()
    {
        return playTimeData.isFinishPlayTime;
    }
}

public class PlayTimeConstant
{
    public PlayTimeConstant() { }

    // PlayTime은 5분을 기준으로함.
    public float maxTime = 300f;
    public float initCurrentTime = 0f;
    public int secondOver = 10; 
}
