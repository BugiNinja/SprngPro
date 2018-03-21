using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamicamera : MonoBehaviour {

    GameObject player;
    Camera c;

	void Start () {
        player = GameObject.FindGameObjectWithTag("PLayer");
        c = gameObject.GetComponent<Camera>();
	}
	

	void Update () {
		
	}
}
