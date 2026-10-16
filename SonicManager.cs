using System;
using UnityEngine;
using UnityEngine.Audio;

public class SonicManager : MonoBehaviour
{
    public static SonicManager instance;
    public Sound[] sounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        foreach(Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }
    public void PlaySound(string sonic)
    {
        Sound sound = Array.Find<Sound>(sounds,item => item.name == sonic);
        sound.audioSource.Play();
    }
    public void StopSound(string sonic)
    {
        Sound sound = Array.Find<Sound>(sounds,item => item.name == sonic);
        sound.audioSource.Stop();
    }
}