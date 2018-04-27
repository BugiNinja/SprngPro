using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {
    public GameObject[] Characters;
    public Interactable[] InteractableObjects;
    public bool[] Triggers = new bool[10];
    public Dictionary<string, int> Inventory = new Dictionary<string, int>(); //Ehkä tallennukseen

    void Start()
    {
        Triggers[0] = true;
        GameObject[] NPC = GameObject.FindGameObjectsWithTag("NPC");
        Characters = new GameObject[NPC.Length + 1];
        Characters[0] = GameObject.FindGameObjectWithTag("Player");
        for(int i = 0; i < NPC.Length; i++)
        {
            Characters[i + 1] = NPC[i];
        }
        GameObject[] InteractableGameObjects = GameObject.FindGameObjectsWithTag("Interactable");
        InteractableObjects = new Interactable[InteractableGameObjects.Length];
        for(int i = 0; i < InteractableGameObjects.Length; i++)
        {
            InteractableObjects[i] = InteractableGameObjects[i].GetComponent<Interactable>();
        }

    }
	
	
	void Update ()
    {
		
	}
    private void CheckTriggers()
    {
        if (Triggers[1])
        {
            InteractableObjects[0].Dissable(); //apple
        }
        if (Triggers[2])
        {
            Interactable i = Characters[1].GetComponent<Interactable>();
            i.SwitchDialog(4);
        }
    }
    public GameObject[] GetCharacters()
    {
        return Characters;
    }
    public void ResetTriggers()
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i] = false;
        }
    }
    public void ReturnTrigger(int triggerIndex)
    {
        SwitchTrigger(triggerIndex);
        CheckTriggers();
    }
    private void SwitchTrigger(int trigger)
    {
        Triggers[trigger] = true;
    }
    
}
