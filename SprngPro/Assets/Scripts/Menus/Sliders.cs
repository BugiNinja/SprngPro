using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour {

    private Menu menu;

    private Slider master;
    private Slider music;
    private Slider sound;

    public float MasterValue;
    public float MusicValue;
    public float SoundValue;

    void Start () {
        menu = GameObject.Find("OptionsMenu").GetComponent<Menu>();

        master = GameObject.Find("Slider1").GetComponent<Slider>();
        music = GameObject.Find("Slider2").GetComponent<Slider>();
        sound = GameObject.Find("Slider3").GetComponent<Slider>();

        master.value = AudioManager.Instance.MasterVol;
        music.value = AudioManager.Instance.MusicVol;
        sound.value = AudioManager.Instance.SoundVol;

        master.onValueChanged.AddListener(AudioManager.Instance.AdjustVolume);
        music.onValueChanged.AddListener(AudioManager.Instance.AdjustMusicVolume);
        sound.onValueChanged.AddListener(AudioManager.Instance.AdjustSoundVolume);
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

        MasterValue = master.value;
        MusicValue = music.value;
        SoundValue = sound.value;
    }
}
