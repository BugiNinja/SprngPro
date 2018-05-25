using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour {

    AudioManager am;

    private Menu menu;

    private Slider master;
    private Slider music;
    private Slider sound;

    public float MasterValue;
    public float MusicValue;
    public float SoundValue;

    void Start () {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        menu = GameObject.Find("SoundOptionsMenu").GetComponent<Menu>();

        master = GameObject.Find("Slider1").GetComponent<Slider>();
        music = GameObject.Find("Slider2").GetComponent<Slider>();
        sound = GameObject.Find("Slider3").GetComponent<Slider>();

        master.value = am.MasterVol;
        music.value = am.MusicVol;
        sound.value = am.SoundVol;

        master.onValueChanged.AddListener(am.AdjustVolume);
        music.onValueChanged.AddListener(am.AdjustMusicVolume);
        sound.onValueChanged.AddListener(am.AdjustSoundVolume);
    }

	void Update () {

        if (Input.GetKey(KeyCode.D))
        {
            if (menu.SliderNum == 1)
            {
                if (master.value <= 1)
                {
                    master.value += 0.01f;
                }
            }
            if (menu.SliderNum == 2)
            {
                if (music.value <= 1)
                {
                    music.value += 0.01f;
                }
            }
            if (menu.SliderNum == 3)
            {
                if (sound.value <= 1)
                {
                    sound.value += 0.01f;
                }
            }
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            if (menu.SliderNum == 1)
            {
                if (master.value >= 0)
                {
                    master.value -= 0.01f;
                }
            }
            if (menu.SliderNum == 2)
            {
                if (music.value >= 0)
                {
                    music.value -= 0.01f;
                }
            }
            if (menu.SliderNum == 3)
            {
                if (sound.value >= 0)
                {
                    sound.value -= 0.01f;
                }
            }
        }

        am.MasterVol = master.value;
        am.MusicVol = music.value;
        am.SoundVol = sound.value;
    }
}
