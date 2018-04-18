using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIndicator : MonoBehaviour {

    private Menu menu;

    void Start () {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

	void Update () {
        Vector3 position = transform.position;
        position.y = menu.OptionPosition.y;
        transform.position = position;
    }
}
