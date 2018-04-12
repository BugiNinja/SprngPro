using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour {
    
    private ChangeScenes newScene;

    private void Start()
    {
        newScene = GameObject.Find("SceneChanger").GetComponent<ChangeScenes>();
    }

    public void PlayGame()
    {
        newScene.ChangeScene(1);
    }

    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
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
