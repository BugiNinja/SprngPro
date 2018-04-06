using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuSpawner : MonoBehaviour {

    public GameObject inGameMenu;
    public bool pressedEsc;

    private void Start()
    {
        pressedEsc = false;
        inGameMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pressedEsc)
            {
                inGameMenu.SetActive(true);
                pressedEsc = true;
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
                pressedEsc = false;
                Time.timeScale = 1;
            }
        }
    }
}
