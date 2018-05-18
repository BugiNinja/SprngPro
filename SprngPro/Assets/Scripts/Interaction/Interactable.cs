using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public int Dialogue;
    public bool Timed;
    public bool RandomChar;
    private DialogueManager Dialog;
    
    public enum CharTypes {Default, RichM, RichW, NiceM, PoorM, PoorW}

    public CharTypes CharacterType;

    void Start () {
        Dialog = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

    }
	

	public void Interact()
    {
        if (Timed)
        {
            Dialog.StartTimed(gameObject);
           
        }
        else if (RandomChar)
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
                int type = (int)CharacterType;
                Dialog.StartRandom(gameObject, type);
            }
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

    public bool IsTimed()
    {
        if (Timed)
        {
            return true;
        }
        return false;
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
