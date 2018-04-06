using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour {

    private ChangeScenes newScene;

    private void Start()
    {
        newScene = GameObject.Find("SceneChanger").GetComponent<ChangeScenes>();
    }

    public void Options()
    {
        //Options stuff
        Debug.Log("Options");
    }

    public void ExitGame()
    {
        newScene.ChangeScene(0);
    }
}
