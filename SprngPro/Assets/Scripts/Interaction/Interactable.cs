using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public int Dialogue;
    public bool Random;
    private DialogueManager Dialog;

    void Start () {
        Dialog = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

    }
	

	public void Interact()
    {
        if (Random)
        {
            Dialog.StartRandom();

        }
        else
        {
            if (Dialog.InChoices())
            {
                Dialog.PickChoice();
            }
            else if (Dialog.InDialog())
            {
                Dialog.NextLine();
            }
            else
            {
                Dialog.StartDiealogue(Dialogue);
            }
        }
    }

    public void Dissable()
    {
        gameObject.SetActive(false);
    }
    public void SwitchDialog(int dialogueIndex)
    {
        Dialogue = dialogueIndex;
    }
    
}
