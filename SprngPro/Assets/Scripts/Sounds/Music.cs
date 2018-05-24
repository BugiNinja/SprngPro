using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Music
{
    public string TrackName;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;

    public bool Loop;

    [HideInInspector]
    public AudioSource Source;
}
