using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public int dialogue;
    public DialogueManager Dialog;

    void Start () {
        Dialog = FindObjectOfType<DialogueManager>();
        
    }
	

	public void Interact()
    {
        if (Dialog.InDialog())
        {
            Dialog.NextLine();
        }
        else
        {
            Dialog.StartDiealogue(dialogue);
        }
    }
}
