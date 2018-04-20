using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Manager;

    private void Awake()
    {
        if (Manager == null)
        {
            DontDestroyOnLoad(gameObject);
            Manager = this;
        }
        else if (Manager != this)
        {
            Destroy(gameObject);
            return;
        }
    }
}
