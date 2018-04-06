using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int dialogue;

    public DialogueManager theTextBox;

    public bool requireButtonPress;
    private bool waitForPress;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(waitForPress && Input.GetKeyDown(KeyCode.J))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.EnableTextBox();
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            theTextBox.StartDiealogue(dialogue);
        }

        if(other.tag == "NPC")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
