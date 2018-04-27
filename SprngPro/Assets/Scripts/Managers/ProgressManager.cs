using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {
    public GameObject[] Characters;
    public Interactable[] InteractableObjects;
    public bool[] Triggers = new bool[10]; //Tämä tallennukseen
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
    public void ReturnChoice(int questionIndex, int choice)
    {
        CheckChoices(questionIndex, choice);
        CheckTriggers();
    }
    private void CheckChoices(int questionIndex, int choice)
    {
        switch (questionIndex)
        {
            //case 0 for copying should newer be used;
            case 0:
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                return;
                            }
                        case 2:
                            {
                                return;
                            }
                        case 3:
                            {
                                return;
                            }
                        default:
                            return;
                    }
                }
            case 1: //speaking flanders #1
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                
                                return;
                            }
                        case 2:
                            {
                                
                                return;
                            }
                        case 3:
                            {
                                Triggers[2] = true;
                                return;
                            }
                        default:
                            return;
                    }
                }
            case 2: //stealing apple
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Inventory.Add("Apple", 1);
                                InteractableObjects[0].Dissable(); //apple
                                Triggers[1] = true;
                                return;
                            }
                        case 2:
                            {
                                Triggers[2] = true;
                                return;
                            }
                        case 3:
                            {
                                return;
                            }
                        default:
                            return;
                    }
                }

        }
    }
}
