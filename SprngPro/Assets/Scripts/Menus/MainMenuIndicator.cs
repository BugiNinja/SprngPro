using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuIndicator : MonoBehaviour {

    public MainMenu menu;

    public int menuIndex;
    public int menuIndexMin;
    public int menuIndexMax;

    private void Start()
    {
        menuIndex = 0;
        menuIndexMin = 0;
        menuIndexMax = 3;
    }

    private void Update()
    {
        ChooseMenuIndex();
        CheckIndexCap();
        MoveIndicatorWithKeys();
        //MoveIndicatorWithMouse(); <-- not working yet
        ChooseMenuOption();
    }

    public void ChooseMenuIndex()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            menuIndex++;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            menuIndex--;
        }
    }

    public void ChooseMenuOption()
    {
        if (menuIndex == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            menu.PlayGame();
        }
        else if (menuIndex == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            menu.Options();
        }
        else if (menuIndex == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            menu.Credits();
        }
        else if (menuIndex == 3 && Input.GetKeyDown(KeyCode.Return))
        {
            menu.QuitGame();
        }
    }

    public void MoveIndicatorWithKeys()
    {
        if (menuIndex == 0)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("PlayButton").transform.position.y;
            transform.position = position;
        }
        else if (menuIndex == 1)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("OptionsButton").transform.position.y;
            transform.position = position;
        }
        else if (menuIndex == 2)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("CreditsButton").transform.position.y;
            transform.position = position;
        }
        else if (menuIndex == 3)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("QuitButton").transform.position.y;
            transform.position = position;
        }
    }

    public void MoveIndicatorWithMouse()
    {
        //Code here
    }

    public void CheckIndexCap()
    {
        if(menuIndex < menuIndexMin)
        {
            menuIndex = menuIndexMax;
        }
        else if (menuIndex > menuIndexMax)
        {
            menuIndex = menuIndexMin;
        }
    }
}
