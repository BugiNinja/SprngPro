using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] Sounds;
    public Music[] Tracks;
    public MasterVolume Master;

    public static AudioManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Music m in Tracks)
        {
            m.Source = gameObject.AddComponent<AudioSource>();
            m.Source.clip = m.Clip;

            m.Source.volume = m.Volume * Master.Volume * Master.MusicVolume;
            m.Source.pitch = m.Pitch;
            m.Source.loop = m.Loop;
        }

        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;

            s.Source.volume = s.Volume * Master.Volume * Master.SoundVolume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    private void Start()
    {
        PlayMusic("BG_Music");
    }

    private void Update()
    {
        foreach (Music m in Tracks)
        {
            m.Source.volume = m.Volume * Master.Volume * Master.MusicVolume;
        }

        foreach (Sound s in Sounds)
        {
            s.Source.volume = s.Volume * Master.Volume * Master.SoundVolume;
        }
    }

    public void PlayMusic (string name)
    {
        Music m = Array.Find(Tracks, Music => Music.TrackName == name);
        m.Source.Play();
    }

    public void PlaySound (string name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.SoundName == name);
        s.Source.Play();
    }

    public void AdjustVolume(float newVolume)
    {
        Master.Volume = newVolume;
    }
    public void AdjustSoundVolume(float newVolume)
    {
        Master.SoundVolume = newVolume;
    }
    public void AdjustMusicVolume(float newVolume)
    {
        Master.MusicVolume = newVolume;
    }
}
