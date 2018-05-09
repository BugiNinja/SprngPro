using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    private AudioManager audioManager;

    public string AudioName;
    public float AudioVolume;
    public float AudioPitch;

    void Start () {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void MakeStepSound()
    {
        audioManager.PlaySound(audioManager.RandomSoundName(1, 7), audioManager.RandomSoundVolume(), audioManager.RandomSoundPitch());
    }

    void MakeHammerSound()
    {
        audioManager.PlaySound(audioManager.RandomSoundName(12, 18), 1, 1);
    }
}
