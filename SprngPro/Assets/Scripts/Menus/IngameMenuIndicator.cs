using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuIndicator : MonoBehaviour {

    public IngameMenu igMenu;

    public int menuIndex;
    public int menuIndexMin;
    public int menuIndexMax;

    private void Start()
    {
        menuIndex = 0;
        menuIndexMin = 0;
        menuIndexMax = 1;
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
            menuIndex++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            menuIndex--;
        }
    }

    public void ChooseMenuOption()
    {
        if (menuIndex == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            igMenu.Options();
        }
        else if (menuIndex == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            igMenu.ExitGame();
        }
    }

    public void MoveIndicatorWithKeys()
    {
        if(menuIndex == 0)
        {
            Vector3 position = transform.position;
            position.y = GameObject.Find("OptionsButton").transform.position.y;
            transform.position = position;
        }
        else if(menuIndex == 1)
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
        if (menuIndex < menuIndexMin)
        {
            menuIndex = menuIndexMax;
        }
        else if (menuIndex > menuIndexMax)
        {
            menuIndex = menuIndexMin;
        }
    }
}
