using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuSpawner : MonoBehaviour {

    public Menu menu;
    private bool pressedEsc;

    private void Start()
    {
        menu = GameObject.Find("Menu").GetComponent<Menu>();
        pressedEsc = false;
        menu.gameObject.SetActive(false);
    }

    private void Update()
    {
        SpawnMenu();
    }

    public void SpawnMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pressedEsc)
            {
                menu.gameObject.SetActive(true);
                pressedEsc = true;
                if (Time.timeScale == 1)
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
                menu.gameObject.SetActive(false);
                pressedEsc = false;
                Time.timeScale = 1;
            }
        }
    }
}
