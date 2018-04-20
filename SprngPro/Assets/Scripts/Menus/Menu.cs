﻿using UnityEngine;

public class Menu : MonoBehaviour {

    public MenuOptions Option;

    public string OptionName;
    private int optionCount;
    public int[] MenuIndex;
    public int N;
    public Vector3 OptionPosition;

    public int SliderNum;

	void Awake () {
        Option = gameObject.GetComponent<MenuOptions>();

        optionCount = transform.GetChild(0).childCount;
        MenuIndex = new int[optionCount - 1];
        N = 0;

        OptionName = transform.GetChild(0).GetChild(N).name;
        OptionPosition = transform.GetChild(0).Find(OptionName).position;

        SliderNum = 0;
    }

	void Update () {
        ChangeInteger();
        CheckIndexCap();
        ChooseOption();
	}

    void ChangeInteger()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            N++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            N--;
        }
    }

    public void CheckIndexCap()
    {
        if (N < 0)
        {
            N = MenuIndex.Length;
        }
        else if (N > MenuIndex.Length)
        {
            N = 0;
        }
    }

    void ChooseOption()
    {
        OptionName = transform.GetChild(0).GetChild(N).name;
        OptionPosition = transform.GetChild(0).GetChild(N).position;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(OptionName == "PlayButton")
            {
                Option.PlayGame();
            }
            if (OptionName == "ContinueButton")
            {
                Option.Continue();
            }
            if (OptionName == "OptionsButton")
            {
                Option.Options();
            }
            if (OptionName == "CreditsButton")
            {
                Option.Credits();
            }
            if (OptionName == "BackButton")
            {
                Option.Back();
            }
            if (OptionName == "ExitButton")
            {
                Option.ExitGame();
            }
            if (OptionName == "QuitButton")
            {
                Option.QuitGame();
            }
        }

        if (OptionName == "MasterSlider")
        {
            SliderNum = 1;
        }
        if (OptionName == "MusicSlider")
        {
            SliderNum = 2;
        }
        if (OptionName == "SoundSlider")
        {
            SliderNum = 3;
        }
        if (N > 2)
        {
            SliderNum = 0;
        }
    }
}
