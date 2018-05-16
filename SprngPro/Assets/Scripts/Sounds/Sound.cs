using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {
    public string SoundName;
    public string SourceObjectName;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(0.5f, 3f)]
    public float Pitch;

    public bool Loop;

    public bool AreaEffect;

    //[HideInInspector]
    public AudioSource Source;
}
