using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    TextBoxCanvas textBox;
    public GameObject button;
    private int interactableCount;
    public List<Interactable> inter;
    private int interactWith = 0;
    public DialogueManager Dialog;
    private bool dissableInput;

    private void Start () {
        textBox = GameObject.Find("TextBoxCanvas").GetComponent<TextBoxCanvas>();
        Dialog = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        interactableCount = -1;
	}

	private void Update () {
		if(interactableCount > -1)
        {
            
            if (Input.GetKeyDown(KeyCode.E) && !dissableInput)
            {
                HideButton();
                inter[interactWith].Interact();
            }
            if (Dialog.InChoices())
            {
                if (Input.GetKeyDown(KeyCode.S) && !dissableInput)
                {
                    
                    Dialog.SwitchChoice(1);
                }
                else if (Input.GetKeyDown(KeyCode.W) && !dissableInput)
                {
                    Dialog.SwitchChoice(-1);
                }
            }
            else if (Dialog.InDialog())
            { 

                if (Input.GetKeyDown(KeyCode.DownArrow) && interactableCount > 0)
                {
                    SwitchInteractable(-1);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && interactableCount > 0)
                {
                    SwitchInteractable(1);
                }
            }
            else if (!Dialog.InDialog())
            {
                ShowButton();
            }
            for(int i = 0; i < inter.Count; i++)
            {
                if (!inter[i].gameObject.activeSelf)
                {
                    inter.RemoveAt(i);
                }
            }
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable" || other.gameObject.tag == "NPC")
        {
            if (other.gameObject.GetComponent<Interactable>())
            {
                Interactable i = other.gameObject.GetComponent<Interactable>();
                
                if (i.IsTimed())
                {
                    i.Interact();
                }
                else
                {
                    inter.Add(i);
                    button = GameObject.Find(i.gameObject.name + "/TextBoxCanvas/Button");
                    ShowButton();
                    if (inter != null)
                    {
                        interactableCount++;
                    }
                }
                
            }

        }
    }
    private void ShowButton()
    {
        button.SetActive(true);
    }
    private void HideButton()
    {
        button.SetActive(false);
    }
    public void EnableInput(bool state)
    {
        if(state == true)
        {
            dissableInput = false;
        }
        else
        {
            dissableInput = true;
        }
        
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable" || other.gameObject.tag == "NPC")
        {
            HideButton();
            Interactable i = other.gameObject.GetComponent<Interactable>();
            inter.Remove(i);
            interactableCount--;
        }
    }

    private void SwitchInteractable(int input)
    {
        
        interactWith += input;
        if(interactableCount < interactWith)
        {
            interactWith = 0;
        }
        else if(interactWith < 0)
        {
            interactWith = interactableCount;
        }
    }
}
