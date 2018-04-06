using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public TextAsset dialogFile;
    public GameObject[] Characters;

    private GameObject textBox;
    private Text dialogue;

    private bool isActive;

    private int currentLine;
    private int speakingChar;

    private string[] dialogLines;
    private List<int> dialogueStartLines;

    private PlayerPathMove pMove;
    
    

    private void Start()
    {
        pMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPathMove>();
        if (dialogFile != null)
        {
            dialogLines = (dialogFile.text.Split('\n'));
        }
        int  conI = 1;
        for(int i = 0; i < dialogLines.Length - 1; i++)
        {
            if (dialogLines[i].StartsWith("#" + conI ))
            {
                dialogueStartLines.Add(i + 1);
                conI++;
            }
        }
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        dialogue.text = dialogLines[currentLine];

        CheckDialogue();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextLine();
        }
    }

    public void StartDiealogue(int DialogueIndex)
    {
        currentLine = dialogueStartLines[DialogueIndex - 1];
        CheckDialogue();
        EnableTextBox();
    }

    public void NextLine()
    {
        currentLine += 1;
        
    }

    private void CheckDialogue()
    {
        if (dialogLines[currentLine].StartsWith("."))
        {
            int.TryParse(dialogLines[currentLine].Remove(0, 1), out speakingChar);
            speakingChar -= 1;
            currentLine++;
            ChanceCharacter(speakingChar);
        }
        if (dialogLines[currentLine].StartsWith("!"))
        {
            DisableTextBox();
        }
        if (dialogLines[currentLine].StartsWith("-"))
        {
            int choiceIndex = 0;
            int.TryParse(dialogLines[currentLine].Remove(0, 1), out choiceIndex);
            StartPlayerChoice(choiceIndex);
        }
    }
    
    private void ChanceCharacter(int speakingChar)
    {
        DisableTextBox();
        textBox = GameObject.Find(Characters[speakingChar].name + "/TextBoxCanvas/TextBoxContainer");
        dialogue = GameObject.Find(Characters[speakingChar].name + "/TextBoxCanvas/TextBoxContainer/TextBg/Dialogue").GetComponent<Text>();
        EnableTextBox();
    }

    private void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        pMove.EnableMovement(false);
    }

    private void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        pMove.EnableMovement(true);
    }

    public bool InDialog()
    {
        return isActive;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            dialogLines = new string[1];
            dialogLines = (theText.text.Split('\n'));
        }
    }

    private void StartPlayerChoice(int choice)
    {
        
    }
}
