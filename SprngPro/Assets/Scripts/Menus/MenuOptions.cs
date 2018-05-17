using UnityEngine;

public class MenuOptions : MonoBehaviour {

    private FileManager fileManager;
    private SceneChange newScene;
    private MenuActivator activator;

    private void Start()
    {
        fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
        if (!fileManager)
        {
            Debug.Log("FileManager doesn't exist!");
        }
        newScene = GameObject.Find("SceneManager").GetComponent<SceneChange>();
        activator = GameObject.Find("MenuActivator").GetComponent<MenuActivator>();
    }

    public void NewGame()
    {
        fileManager.InitNewGame();
        newScene.ChangeScene(2);
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
        fileManager.SaveGame(n);
        Back();
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void LoadFile(int n)
    {
        newScene.ChangeScene(2);
        fileManager.LoadGame(n);
    }

    public void Erase(int n)
    {
        fileManager.EraseFile(n);
    }
}
