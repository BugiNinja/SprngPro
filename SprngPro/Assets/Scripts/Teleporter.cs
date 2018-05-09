using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    private SceneChange newScene;
    public bool right;
    public int NextSceneNumber;

    private void Start()
    {
        newScene = GameObject.Find("SceneManager").GetComponent<SceneChange>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (right)
            {
                newScene.ChangeScene(NextSceneNumber, 1);
            }
            else
            {
                newScene.ChangeScene(NextSceneNumber, -1);
            }
  
        }
    }
}
