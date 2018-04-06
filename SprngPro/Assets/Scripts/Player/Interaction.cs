using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    private bool canInteract;
    private int interactableCount;

	void Start () {
        canInteract = false;
        interactableCount = 0;
	}

	void Update () {
		if(interactableCount > 0)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
	}

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable" || other.gameObject.tag == "NPC")
        {
            interactableCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable" || other.gameObject.tag == "NPC")
        {
            interactableCount--;
        }
    }*/

    /*private void ChooseInteractable()
    {
        if(interactableCount > 1)
        {

        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {

    }
}
