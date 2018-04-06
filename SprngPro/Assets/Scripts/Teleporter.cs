using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public ChangeScenes NewScene;
    public int NextSceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            NewScene.ChangeScene(NextSceneNumber);
        }
    }
}
