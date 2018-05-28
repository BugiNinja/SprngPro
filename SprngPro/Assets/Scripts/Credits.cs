using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {
    private SceneChange sc;
	// Use this for initialization
	void Start () {
        sc = FindObjectOfType<SceneChange>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sc.ChangeScene(0);
        }
	}
}
