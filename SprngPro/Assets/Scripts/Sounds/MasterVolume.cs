using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class MasterVolume
{
    [Range(0f, 1f)]
    public float Volume;
    [Range(0f, 1f)]
    public float MusicVolume;
    [Range(0f, 1f)]
    public float SoundVolume;
}
