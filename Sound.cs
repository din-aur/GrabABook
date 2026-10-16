using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;
    [Range (0f,1f)] public float volume = 1;
    [Range (-3f,3f)] public float pitch = 1;
    public bool loop = false;
    [HideInInspector] public AudioSource audioSource;
}