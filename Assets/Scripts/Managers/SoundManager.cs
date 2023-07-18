using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public Soundtype[] Sounds;

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    private void Awake()
    {
        if(instance == null)
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
        PlayMusic(global::Sounds.GameMusic);
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip!=null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip!=null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        Soundtype item = Array.Find(Sounds, i => i.soundType == sound);
        if(item!=null)
        {
            return item.soundClip;
        }
        return null;
    }


}

[Serializable]
public class Soundtype
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    GameMusic,
    PlayerSpawn,
    EnemyDie,
    PlayerDeath,
    PlayerAttack,
    EnemyAttack,
    PlayerJump,
    ButtonClick
}
