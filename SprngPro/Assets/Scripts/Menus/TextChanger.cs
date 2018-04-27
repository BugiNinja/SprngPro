using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {

    public Text[] FileText = new Text[4];

    void Awake () {
        FileText[0] = null;
        FileText[1] = GameObject.Find("FileText1").GetComponent<Text>();
        FileText[2] = GameObject.Find("FileText2").GetComponent<Text>();
        FileText[3] = GameObject.Find("FileText3").GetComponent<Text>();

        FileText[1].text = "(Empty)";
        FileText[2].text = "(Empty)";
        FileText[3].text = "(Empty)";
    }

    private void Update()
    {
        for (int i = 1; i < FileText.Length; i++)
        {
            if (FileManager.Instance.SaveSlots[i])
            {
                FileText[i].text = "FILE" + i;
            }
            else
            {
                FileText[i].text = "(Empty)";
            }
        }
    }
}
