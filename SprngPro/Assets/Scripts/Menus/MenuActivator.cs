using UnityEngine;

public class MenuActivator : MonoBehaviour
{
    public Menu MainMenu;
    public Menu OptionsMenu;
    public bool MenuActivated;
    public bool OptionsActivated;
    public bool MenuLockedInScreen;

    private void Awake()
    {
        MainMenu = GameObject.Find("Menu").GetComponent<Menu>();
        OptionsMenu = GameObject.Find("OptionsMenu").GetComponent<Menu>();
        MenuActivated = MenuLockedInScreen;
        OptionsActivated = false;
        MainMenu.gameObject.SetActive(MenuLockedInScreen);
        OptionsMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        ActivateMainMenu();
        ActivateOptionsMenu();

        if (MenuActivated)
        {
            MainMenu.gameObject.SetActive(true);
        }
        else
        {
            MainMenu.gameObject.SetActive(false);
        }

        if (OptionsActivated)
        {
            OptionsMenu.gameObject.SetActive(true);
        }
        else
        {
            OptionsMenu.gameObject.SetActive(false);
        }

        if (OptionsActivated || MenuActivated)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void ActivateMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MenuActivated && !OptionsActivated)
            {
                MenuActivated = true;
            }
            else if (MenuActivated)
            {
                MenuActivated = MenuLockedInScreen;
            }
        }
    }

    void ActivateOptionsMenu()
    {
        if (OptionsActivated)
        {
            MenuActivated = false;
            MainMenu.gameObject.SetActive(false);
            OptionsMenu.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && OptionsActivated)
        {
            OptionsActivated = false;
            MenuActivated = true;
        }
    }
}
