using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour {

    /*public TextFromTextfile nameText;
    public TextFromTextfile dialogueText;
    public Canvas messageCanvas;
    public bool isInConversation;

    private void Start()
    {
        isInConversation = false;
        messageCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC" || other.tag == "Interactable" && !isInConversation)
        {
            TurnOnMessage();
            TriggerDialogue();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC" && Input.GetKeyDown(KeyCode.E) && !isInConversation)
        {
            isInConversation = true;
            TurnOnMessage();
            TriggerDialogue();
        }
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            isInConversation = false;
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(nameText);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueText);
    }*/
}
