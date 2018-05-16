using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public Sound[] Sounds;
    public Music[] Tracks;
    public MasterVolume Master;

    public float MasterVol;
    public float MusicVol;
    public float SoundVol;

    public static AudioManager Instance;

    void Awake()
    {
        MasterVol = Master.Volume;
        MusicVol = Master.MusicVolume;
        SoundVol = Master.SoundVolume;

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
            try
            {
                s.Source = GameObject.Find(s.SourceObjectName).AddComponent<AudioSource>();
            }
            catch
            {
                s.Source = gameObject.AddComponent<AudioSource>();
            }

            s.Source.clip = s.Clip;

            s.Source.volume = s.Volume * Master.Volume * Master.SoundVolume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;

            if (s.AreaEffect)
            {
                s.Source.spatialBlend = Master.SpatialBlend;
                s.Source.rolloffMode = AudioRolloffMode.Linear;
                s.Source.minDistance = Master.MinDistance;
                s.Source.maxDistance = Master.MaxDistance;
            }
        }
    }

    private void Start()
    {
        PlaySound("WindAmbient");
        PlaySound("CrowdAmbient");
        PlaySound("BS_Fire");
        //PlayMusic("");
    }

    private void Update()
    {
        MasterVol = Master.Volume;
        MusicVol = Master.MusicVolume;
        SoundVol = Master.SoundVolume;

        foreach (Music m in Tracks)
        {
            m.Source.volume = m.Volume * Master.Volume * Master.MusicVolume;
            m.Source.pitch = m.Pitch;
        }

        foreach (Sound s in Sounds)
        {
            s.Source.volume = s.Volume * Master.Volume * Master.SoundVolume;
            s.Source.pitch = s.Pitch;

            if (s.AreaEffect)
            {
                s.Source.spatialBlend = Master.SpatialBlend;
                s.Source.minDistance = Master.MinDistance;
                s.Source.maxDistance = Master.MaxDistance;
            }
        }
    }

    public void PlayMusic (string name)
    {
        Music m = Array.Find(Tracks, Music => Music.TrackName == name);
        if(m != null)
        {
            m.Source.Play();
        }
        
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.SoundName == name);
        if(s != null)
        {
            s.Source.Play();
        }
        
    }

    public void PlaySound (string name, float volume, float pitch)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.SoundName == name);
        s.Pitch = pitch;
        s.Volume = volume;
        s.Source.Play();
    }

    public float RandomSoundPitch()
    {
        float pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        return pitch;
    }

    public float RandomSoundVolume()
    {
        float volume = UnityEngine.Random.Range(0.2f, 0.6f);
        return volume;
    }

    public string RandomSoundName(int minRange, int maxRange)
    {
        int index = UnityEngine.Random.Range(minRange - 1, maxRange - 1);
        string soundName = Sounds[index].SoundName;
        return soundName;
    }

    public void AdjustVolume(float newVolume)
    {
        Master.Volume = newVolume;
    }
    public void AdjustMusicVolume(float newVolume)
    {
        Master.MusicVolume = newVolume;
    }
    public void AdjustSoundVolume(float newVolume)
    {
        Master.SoundVolume = newVolume;
    }
}
