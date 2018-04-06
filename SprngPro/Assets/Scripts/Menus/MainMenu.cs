using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public ChangeScenes NewScene;

    public void PlayGame()
    {
        NewScene.ChangeScene(1);
    }

    public void Options()
    {
        //Code here...
        Debug.Log("Options");
    }

    public void Credits()
    {
        //Code here...
        Debug.Log("Credits");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
