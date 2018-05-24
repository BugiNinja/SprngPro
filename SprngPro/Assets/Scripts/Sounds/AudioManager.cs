using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public MasterVolume Master;

    public float MasterVol;
    public float MusicVol;
    public float SoundVol;

    public bool UsedSliders;

    void Awake()
    {
        MasterVol = Master.Volume;
        MusicVol = Master.MusicVolume;
        SoundVol = Master.SoundVolume;
    }

    private void Start()
    {
        Master.Volume = 1;
        Master.MusicVolume = 1;
        Master.SoundVolume = 1;
    }

    private void Update()
    {
        MasterVol = Master.Volume;
        MusicVol = Master.MusicVolume;
        SoundVol = Master.SoundVolume;
    }

    public void AdjustVolume(float newVolume)
    {        
        Master.Volume = newVolume;
        UsedSliders = true;
        
    }
    public void AdjustMusicVolume(float newVolume)
    {
        Master.MusicVolume = newVolume;
        UsedSliders = true;
    }
    public void AdjustSoundVolume(float newVolume)
    {
        Master.SoundVolume = newVolume;
        UsedSliders = true;
    }
}
