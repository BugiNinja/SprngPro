using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivator : MonoBehaviour {

    public Menu MainMenu;
    public Menu OptionsMenu;
    public bool MenuActivated;
    public bool OptionsActivated;
    public bool Activation;

    void Start() {
        MainMenu = GameObject.Find("Menu").GetComponent<Menu>();
        OptionsMenu = GameObject.Find("OptionsMenu").GetComponent<Menu>();
        MenuActivated = Activation;
        OptionsActivated = false;
        MainMenu.gameObject.SetActive(Activation);
        OptionsMenu.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !OptionsActivated)
        {
            ActivateMainMenu();
        }
        if (MenuActivated)
        {
            OptionsMenu.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
        }
        if (!MenuActivated)
        {
            MainMenu.gameObject.SetActive(false);
        }
        if (OptionsActivated)
        {
            ActivateOptionsMenu();

            if (Input.GetKeyDown(KeyCode.Escape) ||
                Input.GetKeyDown(KeyCode.Return))
            {
                CloseOptionsMenu();
            }
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
        if (!MenuActivated)
        {
            MenuActivated = true;
        }
        else
        {
            MenuActivated = Activation;
        }
    }

    void ActivateOptionsMenu()
    {
        MainMenu.gameObject.SetActive(false);
        OptionsMenu.gameObject.SetActive(true);
    }

    void CloseOptionsMenu()
    {
        OptionsActivated = false;
        OptionsMenu.gameObject.SetActive(false);
        MenuActivated = true;
        MainMenu.gameObject.SetActive(true);
    }
}
