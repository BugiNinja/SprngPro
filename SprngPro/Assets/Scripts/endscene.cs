using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endscene : MonoBehaviour {
    private SceneChange sc;
    public bool end;
	// Use this for initialization
	void Start () {
        sc = FindObjectOfType<SceneChange>();
	}
	
	// Update is called once per frame
	void Update () {
        if (end)
        {
            sc.ChangeScene(4);
        }
	}
}
