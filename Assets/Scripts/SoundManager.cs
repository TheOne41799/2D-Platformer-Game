using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioSource soundBackgroundMusic;

    [SerializeField] private bool isMute = false;
    [SerializeField][Range(0f, 1f)] private float volume = 1f;

    public SoundType[] sounds;    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        SetBackgroundMusicVolume(0.1f);
        SetSoundSFXVolume(0.9f);        

        PlayBackgroundMusic(Sounds.BACKGROUND_MUSIC);
    }


    public void PlayBackgroundMusic(Sounds sound)
    {
        if (isMute) return;

        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            soundBackgroundMusic.clip = clip;
            soundBackgroundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for the sound type: " + sound);
        }
    }


    public void Play(Sounds sound)
    {
        if (isMute) return;

        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for the sound type: " + sound);
        }
    }


    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);

        if (item != null)
        {
            return item.soundClip;
        }
        else
        {
            return null; 
        }
    }


    public void Mute(bool status)
    {
        isMute = status;
    }


    public void SetBackgroundMusicVolume(float vol)
    {
        volume = vol;
        soundBackgroundMusic.volume = volume;
    }


    public void SetSoundSFXVolume(float vol)
    {
        volume = vol;
        soundEffect.volume = volume;
    }
}


[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}


public enum Sounds
{
    BUTTON_CLICK,
    BUTTON_CLICK_LEVEL_LOCKED,
    PICK_UP,
    PLAYER_MOVE,
    PLAYER_HIT,
    PLAYER_DEATH,
    ENEMY_DEATH,
    BACKGROUND_MUSIC,
    LEVEL_COMPLETE,
    PLAYER_JUMP,
    PLAYER_LAND
}
