using UnityEngine;
using UnityEngine.UI;

public class MenuActivator : MonoBehaviour
{
    public Menu MainMenu;
    public Menu OptionsMenu;
    public Menu FileMenu;

    private PlayerPathMove ppm;
    private Interaction inter;

    public bool MenuActivated;
    public bool OptionsActivated;
    public bool FileMenuActivated;
    public bool MenuLockedInScreen;

    private void Awake()
    {
        MainMenu = GameObject.Find("Menu").GetComponent<Menu>();
        OptionsMenu = GameObject.Find("OptionsMenu").GetComponent<Menu>();
        FileMenu = GameObject.Find("FileMenu").GetComponent<Menu>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if(p != null)
        {
            ppm = p.GetComponent<PlayerPathMove>();
            inter = p.GetComponent<Interaction>();
        }
        MenuActivated = MenuLockedInScreen;
        OptionsActivated = false;
        FileMenuActivated = false;
        MainMenu.gameObject.SetActive(MenuLockedInScreen);
        OptionsMenu.gameObject.SetActive(false);
        FileMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        ActivateMainMenu();
        ActivateOptionsMenu();
        ActivateLoadMenu();

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

        if (FileMenuActivated)
        {
            FileMenu.gameObject.SetActive(true);
        }
        else
        {
            FileMenu.gameObject.SetActive(false);
        }

        if (OptionsActivated || MenuActivated || FileMenuActivated)
        {
            if (inter != null) {
                inter.EnableInput(false);
                ppm.EnableMovement(false);
            }
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
                if (inter != null)
                {
                    inter.EnableInput(true);
                    ppm.EnableMovement(true);
                }
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

    void ActivateLoadMenu()
    {
        if (FileMenuActivated)
        {
            MenuActivated = false;
            MainMenu.gameObject.SetActive(false);
            FileMenu.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && FileMenuActivated)
        {
            FileMenuActivated = false;
            MenuActivated = true;
        }
    }
}
