using UnityEngine;

public class MenuOptions : MonoBehaviour {

    private ChangeScenes newScene;
    private MenuActivator activator;

    private void Start()
    {
        newScene = GameObject.Find("SceneChanger").GetComponent<ChangeScenes>();
        activator = GameObject.Find("MenuActivator").GetComponent<MenuActivator>();
    }

    public void NewGame()
    {
        FileManager.Instance.InitNewGame();
        newScene.ChangeScene(1);
    }

    public void SaveLoadGame()
    {
        activator.FileMenuActivated = true;
    }

    public void Continue()
    {
        activator.MenuActivated = false;
    }

    public void Options()
    {
        activator.OptionsActivated = true;
    }

    public void Credits()
    {
        Debug.Log("Credits");
    }

    public void Back()
    {
        if (activator.OptionsActivated)
        {
            activator.OptionsActivated = false;
            activator.MenuActivated = true;
        }
        else if (activator.FileMenuActivated)
        {
            activator.FileMenuActivated = false;
            activator.MenuActivated = true;
        }
    }

    public void ExitGame()
    {
        newScene.ChangeScene(0);
    }

    public void Save(int n)
    {
        FileManager.Instance.SaveGame(n);
        Back();
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void LoadFile(int n)
    {
        newScene.ChangeScene(1);
        FileManager.Instance.LoadGame(n);
    }

    public void Erase(int n)
    {
        FileManager.Instance.EraseFile(n);
    }
}
