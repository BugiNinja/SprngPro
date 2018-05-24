using System;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    public Sound[] Sounds;
    private AudioManager am;

    private void Awake()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            
            s.Source.volume = s.Volume * am.MasterVol * am.SoundVol;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
            s.Source.playOnAwake = s.PlayOnAwake;

            if (s.SpatialBlend)
            {
                s.Source.spatialBlend = 1;
            }
            else
            {
                s.Source.spatialBlend = 0;
            }
            s.Source.minDistance = s.MinDistance;
            s.Source.maxDistance = s.MaxDistance;

            s.Source.rolloffMode = AudioRolloffMode.Linear;
        }
    }

    private void Start()
    {
        foreach (Sound s in Sounds)
        {
            if (s.PlayOnAwake)
            {
                PlaySound(s.SoundName, s.Volume * am.MasterVol * am.SoundVol, 1f);
            }
        }
    }

    private void Update()
    {
        if(am.UsedSliders)
        {
            ChangeValues();
        }
    }

    void MakeStepSound()
    {
        PlaySound(RandomSoundName(1, 7), RandomSoundVolume(), RandomSoundPitch());
    }

    void MakeHammerSound()
    {
        PlaySound(RandomSoundName(1, 7), 0.5f, 1);
    }

    void PlaySound(string name, float volume, float pitch)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.SoundName == name);
        s.Volume = volume;
        s.Source.volume = s.Volume;
        s.Pitch = pitch;
        s.Source.pitch = s.Pitch;
        s.Source.Play();
        if(!s.PlayOnAwake)
        {
            ChangeValues();
        }
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
        int index = UnityEngine.Random.Range(minRange - 1, maxRange);
        string soundName = Sounds[index].SoundName;
        return soundName;
    }

    void ChangeValues()
    {
        foreach(Sound s in Sounds)
        {
            s.Source.volume = s.Volume * am.MasterVol * am.SoundVol;
        }
        am.UsedSliders = false;
    }
}
