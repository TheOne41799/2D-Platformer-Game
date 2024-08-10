using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public SoundType[] sounds;
    [SerializeField] AudioSource soundEffect;


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


    public void Player(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);

        if (clip != null) 
        {

    }


    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, item => item.soundType == sound);

        if (item != null)
        {
            return item.soundClip;
        }
        else
        {
            return null; 
        }
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
    PLAYER_MOVE,
    PLAYER_DEATH,
    ENEMY_DEATH
}
