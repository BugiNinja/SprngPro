using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {
    public string SoundName;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(0.5f, 3f)]
    public float Pitch;

    public bool Loop;
    public bool PlayOnAwake;

    public bool SpatialBlend;
    public int MinDistance;
    public int MaxDistance;

    //[HideInInspector]
    public AudioSource Source;
}
