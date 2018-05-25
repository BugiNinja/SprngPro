using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {
    string[] NPCNames = {"BoxBoy", "Trader", "Blacksmith" };
    string[] InterNames = { "Meat" };
    public GameObject[] Characters;
    public Interactable[] InteractableCharacters;
    public Interactable[] InteractableObjects;
    private SceneChange sc;
    public bool[] Triggers = new bool[11];
    public Dictionary<string, int> Inventory = new Dictionary<string, int>(); //Ehkä tallennukseen
    private PlayerStats ps;
    private bool won;

    void Start()
    {
        won = false;
        Triggers[0] = true;
        sc = FindObjectOfType<SceneChange>();
        UpdateCharacters();
        UpdateInteractable();
        
    }

    public void UpdateCharacters()
    {
        GameObject[] NPC = GameObject.FindGameObjectsWithTag("NPC");
        InteractableCharacters = new Interactable[NPCNames.Length];
        Characters = new GameObject[5];
        Characters[0] = GameObject.FindGameObjectWithTag("Player");
        if(Characters[0] == null)
        {
            Debug.LogWarning("Player missing!");
        }
        else
        {
            ps = Characters[0].GetComponent<PlayerStats>();
        }
        Characters[1] = null;
        for (int i = 0; i < NPCNames.Length; i++)
        {
            for(int i2 = 0;i2 < NPC.Length; i2++)
            {
                if(NPC[i2].name == NPCNames[i])
                {
                    Characters[i + 2] = NPC[i2];
                    InteractableCharacters[i] = NPC[i2].GetComponent<Interactable>();
                }
            }
            
        }
    }
    public void UpdateInteractable()
    {
        GameObject[] InteractableGameObjects = GameObject.FindGameObjectsWithTag("Interactable");
        InteractableObjects = new Interactable[InterNames.Length];
        for (int i = 0; i < InteractableGameObjects.Length; i++)
        {
            InteractableObjects[i] = InteractableGameObjects[i].GetComponent<Interactable>();
        }
        for (int i = 0; i < InterNames.Length; i++)
        {
            for (int i2 = 0; i2 < InteractableGameObjects.Length; i2++)
            {
                if (InteractableGameObjects[i2].name == InterNames[i])
                {
                    InteractableObjects[i] = InteractableGameObjects[i2].GetComponent<Interactable>();
                }
            }

        }
    }

    void Update ()
    {
        CheckTriggers();
	}
    private void CheckTriggers()
    {
        if (Triggers[0])
        {

        }
        if (Triggers[1])
        {
            //saa turpaan
            
            ps.Die();
        }
        if (Triggers[9])
        {
            if (InteractableCharacters[0] != null)
            {
               
                InteractableCharacters[0].SwitchDialog(9);
            }
            
        }
        if (Triggers[2])
        {
            //saa kolikkeja
            if(InteractableCharacters[2] != null)
            {
                InteractableCharacters[2].SwitchDialog(7);
            }
            if (InteractableCharacters[1] != null)
            {
                InteractableCharacters[1].SwitchDialog(4);
            }
            
        }
        if (Triggers[3])
        {
            //vaihda sepän dialogi
        }
        if (Triggers[4])
        {
            if (InteractableCharacters[2] != null)
            {
                InteractableCharacters[2].SwitchDialog(8);
            }
            
            if (InteractableCharacters[1] != null)
            {
                InteractableCharacters[1].SwitchDialog(6);
            }
            
        }
        if (Triggers[5])
        {
            if (InteractableCharacters[0] != null)
            {
                InteractableCharacters[0].SwitchDialog(10);
            }
            
            if (InteractableCharacters[2] != null)
            {
                InteractableCharacters[2].SwitchDialog(12);
            }
            
        }
        if (Triggers[6])
        {
            if (InteractableCharacters[0] != null)
            {
                InteractableCharacters[0].SwitchDialog(11);
            }
        }
        if (Triggers[7])
        {
            if (!won)
            {
                sc.ChangeSceneWithFade(5);
                won = true;
            }
            
        }
        if (Triggers[8])
        {
            if (!won)
            {
                sc.ChangeSceneWithFade(6);
                won = true;
            }
        }
        if (Triggers[10])
        {
            if (!won)
            {
                sc.ChangeSceneWithFade(7);
                won = true;
            }
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
