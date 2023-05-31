using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    public AudioSource audioSource;

    public bool isSoundOn = true;

    [Space]
    [Header("Game")]
    public AudioClip homeSoundClip;
    public AudioClip gamePlaySoundClip;
    public AudioClip gameWinSoundClip;
    public AudioClip gameLoseSoundClip;

    //ui
    [Space]
    [Header("UI")]
    public AudioClip uiButtonClickSoundClip;
    public AudioClip playButtonClickSoundClip;

    [Space]
    [Header("Monster")]
    public AudioClip boomberExploSoundClip;

    [Space]
    [Header("Effect")]
    public AudioClip batmanSoundClip;
    public AudioClip bounceBallHitSoundClip;
    public AudioClip bounceBallStartSoundClip;
    public AudioClip fireBallSoundClip;
    public AudioClip kunaiSoundClip;
    public AudioClip magicBoltSoundClip;
    public AudioClip poisonBottleSoundClip;
    public AudioClip poisonSizzleSoundClip;//

    [Space]
    [Header("Item")]
    public AudioClip expSoundClip;
    public AudioClip healSoundClip;
    public AudioClip levelupSoundClip;
}
