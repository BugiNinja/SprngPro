using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    private int interactableCount;
    private List<Interactable> inter;
    private int interactWith = 0;

	private void Start () {
        interactableCount = -1;
	}

	private void Update () {
		if(interactableCount > -1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inter[interactWith].Interact();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && interactableCount > 0)
            {
                SwitchInteractable(-1);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && interactableCount > 0)
            {
                SwitchInteractable(1);
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
                inter.Add(i);
                if(inter != null)
                {
                    interactableCount++;
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable" || other.gameObject.tag == "NPC")
        {
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
