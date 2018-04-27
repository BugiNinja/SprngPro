using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static FileManager Instance;

    public int Health;
    public int WayPoint;

    public bool FileMenuOpened = false;
    public bool EraseMenuOpened = false;

    public bool[] SaveSlots = new bool[4] {false, false, false, false};

    private void Awake()
    {
        Health = 3;
        WayPoint = 0;

        InitSlots();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void InitNewGame()
    {
        Health = 3;
        WayPoint = 0;
    }

    public void InitSlots()
    {
        for (int i = 0; i < SaveSlots.Length; i++)
        {
            SaveSlots[i] = PlayerPrefsX.GetBool("SaveSlot_" + i);
            Health = PlayerPrefs.GetInt("Health_" + i, 0);
            WayPoint = PlayerPrefs.GetInt("LastWayPointId_" + i, 0);
        }
    }

    public void SaveGame(int n)
    {
        SaveSlots[n] = true;
        Debug.Log("Saved");

        PlayerPrefs.SetInt("Health_" + n, Health);
        PlayerPrefs.SetInt("LastWayPointId_" + n, WayPoint);
        PlayerPrefsX.SetBool("SaveSlot_" + n, true);
    }

    public void LoadGame(int n)
    {
        Health = PlayerPrefs.GetInt("Health_" + n, 0);
        WayPoint = PlayerPrefs.GetInt("LastWayPointId_" + n, 0);
    }

    public void EraseFile(int n)
    {
        PlayerPrefs.DeleteKey("Health_" + n);
        PlayerPrefs.DeleteKey("LastWayPointId_" + n);
        PlayerPrefs.DeleteKey("SaveSlot_" + n);
        SaveSlots[n] = false;
    }

    public bool SlotExists()
    {
        for (int i = 1; i < SaveSlots.Length; i++)
        {
            if (SaveSlots[i])
            {
                return true;
            }
        }
        return false;
    }
}

public class PlayerPrefsX
{
    public static void SetBool(string name, bool booleanValue)
    {
        PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
    }

    public static bool GetBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }

    public static bool GetBool(string name, bool defaultValue)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return GetBool(name);
        }

        return defaultValue;
    }
}
