using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    private ChangeScenes newScene;
    public int NextSceneNumber;

    private void Start()
    {
        newScene = GameObject.Find("SceneChanger").GetComponent<ChangeScenes>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            newScene.ChangeScene(NextSceneNumber);
        }
    }
}
