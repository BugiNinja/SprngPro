using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerFix : MonoBehaviour {
    Quaternion iniRot;
    AudioListener listener;

    void Start () {
        iniRot = transform.rotation;
        listener = gameObject.GetComponent<AudioListener>();
    }

    private void LateUpdate()
    {
        listener.transform.rotation = iniRot;
    }
}
