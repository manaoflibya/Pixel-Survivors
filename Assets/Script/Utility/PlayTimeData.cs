using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimeData
{
    public PlayTimeData()
    {

    }

    public float maxTime { get; set; } = 0f;
    public float currentTime { get; set; } = 0f;

    public bool isPlaying { get; set; } = false;
    public bool isFinishPlayTime { get; set; } = false; 
}
