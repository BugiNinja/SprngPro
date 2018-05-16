using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public TextAsset dialogFile;
    public ProgressManager pm;
    public GameObject[] Characters;

    public GameObject textBox;
    private VerticalLayoutGroup textBoxPadding;
    private Text dialogue;

    private bool isActive;

    private int currentLine;
    private int speakingChar;

    private string[] dialogLines;
    public List<int> dialogueStartLines;
    public List<int> RandomStartingLines;

    public bool InChoice = false;
    private int choiceIndex;
    public List<string> choices;

    private PlayerPathMove pMove;

    public int choiceLeftPadding = 25;
    private int leftPaddingDefault;
    private int indicatorOffset = -23;
    private GameObject indicator;

    public bool UseAutoText = false;
    public float TextSpeed = 0.1f;
    private bool Autowrite = false;
    private IEnumerator courutine;

    

    private void Start()
    {
        dialogFile = Resources.Load("Dialogues") as TextAsset;
        if (dialogFile != null)
        {
            dialogLines = (dialogFile.text.Split('\n'));
        }
        if (dialogFile == null)
        {
            Debug.LogWarning("Dialogue file missing!");
        }
        pm = FindObjectOfType<ProgressManager>();
        if (pm == null)
        {
            Debug.LogWarning("Progress Manager missing!");
        }
        UpdatePlayer();

        int  conI = 1;
        for(int i = 0; i < dialogLines.Length - 1; i++)
        {
            if (dialogLines[i].StartsWith("#" + conI ))
            {
                if(dialogLines[i+1].StartsWith(".2"))
                {
                    RandomStartingLines.Add(i + 1);
                }
                dialogueStartLines.Add(i + 1);
                conI++;
            }
        }
        Characters = pm.GetCharacters();
    }

    public void UpdatePlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            pMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPathMove>();
            textBox = GameObject.Find("Player/TextBoxCanvas/TextBoxContainer/TextBg");
        }
        else
        {
            Debug.LogWarning("Player missing!");
        }
        indicator = GameObject.Find("Player/TextBoxCanvas/TextBoxContainer/TextBg/Dialogue/Indicator");
        if (indicator == null)
        {
            Debug.LogWarning("Indicator is missing from player dialog!");
        }
    }

    private void Update()
    {
        if(Characters != null)
        {
            Characters = pm.GetCharacters();
        }
        if (InChoice)
        {
            Highlight(choiceIndex);
            return;
        }
        if (!isActive)
        {
            return;
        }


        if (!Autowrite)
        {
            CheckDialogue();
        }
        
        if (!InChoice)
        {
            if (UseAutoText)
            {
                if (!Autowrite)
                {
                    Autowrite = true;
                    courutine = Print(dialogLines[currentLine]);
                    StartCoroutine(courutine);
                }
            }
            else
            {
                dialogue.text = dialogLines[currentLine];
            }
            
        }
        
        
    }

    public void StartDiealogue(int DialogueIndex)
    {
        currentLine = dialogueStartLines[DialogueIndex - 1];
        CheckDialogue();
        EnableTextBox();
        
    }
    public void StartRandom()
    {
        currentLine = RandomStartingLines[Random.Range(0,RandomStartingLines.Count)];
        CheckDialogue();
        EnableTextBox();
    }

    public void NextLine()
    {
        currentLine += 1;
        Autowrite = false;
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
        else if (dialogLines[currentLine].StartsWith("!"))
        {
            DisableTextBox();
        }
        else if (dialogLines[currentLine].StartsWith("-"))
        {
            ChanceCharacter(0);
            StartPlayerChoice();
        }
        else if (dialogLines[currentLine].StartsWith("?"))
        {
            int choiceIndex = 0;
            int.TryParse(dialogLines[currentLine].Remove(0, 1), out choiceIndex);
            pm.ReturnTrigger(choiceIndex);
            currentLine++;
        }
        else if (dialogLines[currentLine].StartsWith("+"))
        {
            int i = 1;
            while (!dialogLines[currentLine + i].StartsWith("_"))
            {
                i++;
            }
            currentLine += i+1;
            CheckDialogue();
        }
        else if (dialogLines[currentLine].StartsWith("_"))
        {
            currentLine++;
        }
    }
    
    private void ChanceCharacter(int speakingChar)
    {
        DisableTextBox();
        if (Characters[speakingChar] == null)
        {
            Debug.LogWarning(Characters[speakingChar] + " is not in scene! Player will speak instead");
            textBox = GameObject.Find(Characters[0].name + "/TextBoxCanvas/TextBoxContainer/TextBg");
            dialogue = GameObject.Find(Characters[0].name + "/TextBoxCanvas/TextBoxContainer/TextBg/Dialogue").GetComponent<Text>();
        }
        else
        {
            textBox = GameObject.Find(Characters[speakingChar].name + "/TextBoxCanvas/TextBoxContainer/TextBg");
            dialogue = GameObject.Find(Characters[speakingChar].name + "/TextBoxCanvas/TextBoxContainer/TextBg/Dialogue").GetComponent<Text>();
        }
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
    public bool InChoices()
    {
        return InChoice;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            dialogLines = new string[1];
            dialogLines = (theText.text.Split('\n'));
        }
    }

    private void StartPlayerChoice()
    {
        InChoice = true;
        choices.Clear();
        textBoxPadding = textBox.GetComponent<VerticalLayoutGroup>();
        leftPaddingDefault = textBoxPadding.padding.left;
        textBoxPadding.padding.left = leftPaddingDefault + choiceLeftPadding;

        choiceIndex = 0;
        int i = 1;
        do
        {
            if (dialogLines[currentLine + i].StartsWith("+"))
            {
                choices.Add(dialogLines[currentLine + i + 1]);
            }
            i++;
        } while (!dialogLines[currentLine + i].StartsWith("-"));
        currentLine += i + 1;
        string choiceText = choices[0];
        for (i = 1; i < choices.Count; i++)
        {
            choiceText += "\n" + choices[i];
        }
        dialogue.text = choiceText;
    }

    public void SwitchChoice(int amount)
    {
        choiceIndex += amount;
        if (choices.Count - 1 < choiceIndex)
        {
            choiceIndex = 0;
        }
        else if (choiceIndex < 0)
        {
            choiceIndex = choices.Count - 1;
        }

    }
    public void PickChoice()
    {

        InChoice = false;
        textBoxPadding.padding.left = leftPaddingDefault;
        indicator.SetActive(false);

        while (!dialogLines[currentLine].StartsWith("+" + (choiceIndex+1)) && !dialogLines[currentLine].StartsWith("+0"))
        {
            currentLine++;
        }
        currentLine++;
    }
    private void Highlight(int index)
    {
        indicator.SetActive(true);
        RectTransform rt = indicator.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -dialogue.fontSize/2 + indicatorOffset * index);
    }

    public IEnumerator Print(string text)
    {
        dialogue.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(TextSpeed);
        }
        
    }
}
