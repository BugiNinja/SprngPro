using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public Music[] Musics;
    private AudioManager am;

    private void Awake()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        foreach (Music m in Musics)
        {
            m.Source = gameObject.AddComponent<AudioSource>();
            m.Source.clip = m.Clip;

            m.Source.volume = m.Volume * am.MasterVol * am.SoundVol;
            m.Source.loop = m.Loop;
        }
    }

    private void Update()
    {
        if (am.UsedSliders)
        {
            ChangeValues();
        }
    }

    void PlayTrack(string name, float volume)
    {
        Music m = Array.Find(Musics, Music => Music.TrackName == name);
        m.Volume = volume;
        m.Source.volume = m.Volume;
        m.Source.Play();
    }

    void ChangeValues()
    {
        foreach (Music m in Musics)
        {
            m.Source.volume = m.Volume * am.MasterVol * am.SoundVol;
        }
        am.UsedSliders = false;
    }
}
