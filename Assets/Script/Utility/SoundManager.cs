using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoSingleton<SoundManager>
{
    public SoundData soundData;

    private void Start()
    {
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

    public void ChangeAudioSouceLoop(bool isLoop)
    {
        soundData.audioSource.loop = isLoop;
    }

    public void EffectPlay(AudioClip auido, Vector3 pos, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(auido, pos, volume);
    }

    public void SoundPlayOneShot(AudioClip audio)
    {
        soundData.audioSource.PlayOneShot(audio);
    }
}
