using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuSpawner : MonoBehaviour {

    public GameObject inGameMenu;
    public bool PressedEsc;

    private void Start()
    {
        PressedEsc = false;
        inGameMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PressedEsc)
            {
                inGameMenu.SetActive(true);
                PressedEsc = true;
                if(Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
            else
            {
                inGameMenu.SetActive(false);
                PressedEsc = false;
                Time.timeScale = 1;
            }
        }
    }
}
