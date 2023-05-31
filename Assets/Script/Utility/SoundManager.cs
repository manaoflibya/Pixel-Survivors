using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoSingleton<SoundManager>
{
    public SoundData soundData;

    private void Start()
    {
        soundData.isSoundOn = true; 
        soundData.audioSource.loop = true;
        soundData.audioSource.playOnAwake = false;
    }

    public void BGMPlay(AudioClip clip)
    {
        soundData.audioSource.clip = clip;
        soundData.audioSource.Play();
    }

    public void BGMPlayStop()
    {
        if (soundData.audioSource.isPlaying.Equals(true))
        {
            soundData.audioSource.clip = null;
        }
    }

    public void SoundONOFF(bool isOn)
    {
        soundData.isSoundOn = isOn;

        if (isOn.Equals(true))
        {
            soundData.audioSource.volume = 0.2f;
        }
        else
        {
            soundData.audioSource.volume = 0f;
        }
    }

    public void ChangeAudioSouceLoop(bool isLoop)
    {
        soundData.audioSource.loop = isLoop;
    }

    public void EffectPlay(AudioClip auido, Vector3 pos, float volume = 1f)
    {
        if (soundData.isSoundOn.Equals(true))
        {
            AudioSource.PlayClipAtPoint(auido, pos, volume);
        }
    }

    public void SoundPlayOneShot(AudioClip audio)
    {
        if(soundData.isSoundOn.Equals(true))
        {
            soundData.audioSource.PlayOneShot(audio);
        }
    }
}
