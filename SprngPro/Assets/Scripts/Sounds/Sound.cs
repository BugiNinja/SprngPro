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

    public bool AreaEffect;

    [Range(0f, 1f)]
    public float SpatialBlend;
    [Range(0f, 1000000f)]
    public float MinDistance;
    [Range(0f, 1000000f)]
    public float MaxDistance;

    [HideInInspector]
    public AudioSource Source;
}
