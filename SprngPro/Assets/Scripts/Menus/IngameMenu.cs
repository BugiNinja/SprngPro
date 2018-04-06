using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour {

    public ChangeScenes NewScene;

    public void Options()
    {
        //Options stuff
        Debug.Log("Options");
    }

    public void ExitGame()
    {
        NewScene.ChangeScene(0);
    }
}
