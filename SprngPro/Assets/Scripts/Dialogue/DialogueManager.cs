using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public GameObject[] Characters;
    public int speakingChar;

    public TextAsset textFile;
    public string[] textLines;
    public List<int> dialogueStartLines;

    private PlayerPathMove pMove;

    public int currentLine;

    public bool isActive;

    private void Start()
    {
        pMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPathMove>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        int  conI = 1;
        for(int i = 0; i < textLines.Length - 1; i++)
        {
            if (textLines[i].StartsWith("#" + conI ))
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

        theText.text = textLines[currentLine];

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
        if (textLines[currentLine].StartsWith("."))
        {
            int.TryParse(textLines[currentLine].Remove(0, 1), out speakingChar);
            speakingChar -= 1;
            currentLine++;
            ChanceCharacter(speakingChar);
        }
        if (textLines[currentLine].StartsWith("!"))
        {
            DisableTextBox();
        }
    }
    
    public void ChanceCharacter(int speakingChar)
    {
        DisableTextBox();
        textBox = GameObject.Find(Characters[speakingChar].name + "/TextBoxCanvas/TextBoxContainer");
        theText = GameObject.Find(Characters[speakingChar].name + "/TextBoxCanvas/TextBoxContainer/TextBg/Dialogue").GetComponent<Text>();
        EnableTextBox();
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        pMove.EnableMovement(false);
    }

    public void DisableTextBox()
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
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
