using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivator : MonoBehaviour {

    public Menu IngameMenu;
    public Menu OptionsMenu;
    public bool MenuActivated;
    public bool OptionsActivated;
    public bool Activation;

    void Start() {
        IngameMenu = GameObject.Find("Menu").GetComponent<Menu>();
        OptionsMenu = GameObject.Find("OptionsMenu").GetComponent<Menu>();
        MenuActivated = Activation;
        OptionsActivated = false;
        IngameMenu.gameObject.SetActive(Activation);
        OptionsMenu.gameObject.SetActive(false);
    }

    void Update() {
        ActivateIngameMenu();
        ActivateOptionsMenu();

        if (MenuActivated)//TÄSSÄ MÄTTÄÄ... kun painaa OPTIONS, ingamemenu ensin deaktivoituu ja sitten aktivoituu. RATKAISE!
        {
            OptionsMenu.gameObject.SetActive(false);
            IngameMenu.gameObject.SetActive(true);
        }
        if (!MenuActivated)
        {
            IngameMenu.gameObject.SetActive(false);
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

    void ActivateIngameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    void ActivateOptionsMenu()
    {
        if (OptionsActivated)
        {
            IngameMenu.gameObject.SetActive(false);
            OptionsMenu.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) ||
    Input.GetKeyDown(KeyCode.Return))
        {
            if (OptionsActivated)
            {
                OptionsActivated = false;
                OptionsMenu.gameObject.SetActive(false);
                MenuActivated = true;
                IngameMenu.gameObject.SetActive(true);
            }
        }
    }
}
