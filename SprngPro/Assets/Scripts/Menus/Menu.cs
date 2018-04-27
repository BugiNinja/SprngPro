using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public MenuOptions Option;
    Scene currentScene;

    public string OptionName;
    private int optionCount;
    public int[] MenuIndex;
    public int N;
    public Vector3 OptionPosition;

    public int SliderNum;

	void Start () {
        Option = gameObject.GetComponent<MenuOptions>();

        optionCount = transform.GetChild(0).childCount;
        MenuIndex = new int[optionCount - 1];
        N = 0;

        OptionName = transform.GetChild(0).GetChild(N).name;
        OptionPosition = transform.GetChild(0).Find(OptionName).position;

        SliderNum = 0;

        if (!FileManager.Instance.SlotExists() && transform.GetChild(0).childCount == 5 && !FileManager.Instance.FileMenuOpened)
        {
            Destroy(transform.GetChild(0).GetChild(0).gameObject);
            for (int i = 1; i < transform.GetChild(0).childCount; i++)
            {
                transform.GetChild(0).GetChild(i).Translate(0, 40, 0);
            }
            MenuIndex = new int[optionCount - 2];
        }
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
            if(OptionName == "NewGameButton")
            {
                Option.NewGame();
            }
            if(OptionName == "SaveLoadButton")
            {
                FileManager.Instance.FileMenuOpened = true;
                Option.SaveLoadGame();
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
                N = 0;
                FileManager.Instance.EraseMenuOpened = false;
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
            if (OptionName == "FILE" + (N + 1))
            {
                if (SceneManager.GetActiveScene().buildIndex == 0 && !FileManager.Instance.EraseMenuOpened)
                {
                    if (FileManager.Instance.SaveSlots[N + 1])
                    {
                        Option.LoadFile(N + 1);
                        FileManager.Instance.FileMenuOpened = false;
                    }
                    else if (!FileManager.Instance.SaveSlots[N + 1])
                    {
                        //Kerro jotenkin, että paikka tyhjä
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 1 && !FileManager.Instance.EraseMenuOpened)
                {
                    Option.Save(N + 1);
                }
                else if (FileManager.Instance.EraseMenuOpened)
                {
                    Option.Erase(N + 1);
                    FileManager.Instance.FileMenuOpened = false;
                }
            }
            if (OptionName == "EraseButton")
            {
                FileManager.Instance.EraseMenuOpened = true;
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
