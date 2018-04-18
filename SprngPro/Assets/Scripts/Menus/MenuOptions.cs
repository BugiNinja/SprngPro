using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour {

    private ChangeScenes newScene;
    private MenuActivator activator;

    private void Start()
    {
        newScene = GameObject.Find("SceneChanger").GetComponent<ChangeScenes>();
        activator = GameObject.Find("MenuActivator").GetComponent<MenuActivator>();
    }

    public void PlayGame()
    {
        newScene.ChangeScene(1);
    }

    public void Continue()
    {
        activator.MenuActivated = false;
    }

    public void Options()
    {
        activator.OptionsActivated = true;
    }

    public void Credits()
    {
        //Code here...
        Debug.Log("Credits");
    }

    public void Back()
    {
        activator.OptionsActivated = false;
    }

    public void ExitGame()
    {
        newScene.ChangeScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
