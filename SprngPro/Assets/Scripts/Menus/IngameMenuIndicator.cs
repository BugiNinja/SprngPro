using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuIndicator : MonoBehaviour {

    public IngameMenu InGameMenu;

    public int MenuIndex;
    public int MenuIndexMin;
    public int MenuIndexMax;

    private void Start()
    {
        MenuIndex = 0;
        MenuIndexMin = 0;
        MenuIndexMax = 1;
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            MenuIndex++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MenuIndex--;
        }
    }

    public void ChooseMenuOption()
    {
        if (MenuIndex == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            InGameMenu.Options();
        }
        else if (MenuIndex == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            InGameMenu.ExitGame();
        }
    }

    public void MoveIndicatorWithKeys()
    {
        if(MenuIndex == 0)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("OptionsButton").transform.position.y;
            transform.position = position;
        }
        else if(MenuIndex == 1)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("ExitButton").transform.position.y;
            transform.position = position;
        }
    }

    public void MoveIndicatorWithMouse()
    {
        //Code here
    }

    public void CheckIndexCap()
    {
        if (MenuIndex < MenuIndexMin)
        {
            MenuIndex = MenuIndexMax;
        }
        else if (MenuIndex > MenuIndexMax)
        {
            MenuIndex = MenuIndexMin;
        }
    }
}
