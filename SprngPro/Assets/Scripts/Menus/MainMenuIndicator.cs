using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuIndicator : MonoBehaviour {

    public MainMenu Menu;

    public int MenuIndex;
    public int MenuIndexMin;
    public int MenuIndexMax;

    private void Start()
    {
        MenuIndex = 0;
        MenuIndexMin = 0;
        MenuIndexMax = 3;
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
            MenuIndex++;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            MenuIndex--;
        }
    }

    public void ChooseMenuOption()
    {
        if (MenuIndex == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            Menu.PlayGame();
        }
        else if (MenuIndex == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            Menu.Options();
        }
        else if (MenuIndex == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            Menu.Credits();
        }
        else if (MenuIndex == 3 && Input.GetKeyDown(KeyCode.Return))
        {
            Menu.QuitGame();
        }
    }

    public void MoveIndicatorWithKeys()
    {
        if (MenuIndex == 0)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("PlayButton").transform.position.y;
            transform.position = position;
        }
        else if (MenuIndex == 1)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("OptionsButton").transform.position.y;
            transform.position = position;
        }
        else if (MenuIndex == 2)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("CreditsButton").transform.position.y;
            transform.position = position;
        }
        else if (MenuIndex == 3)
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
        if(MenuIndex < MenuIndexMin)
        {
            MenuIndex = MenuIndexMax;
        }
        else if (MenuIndex > MenuIndexMax)
        {
            MenuIndex = MenuIndexMin;
        }
    }
}
