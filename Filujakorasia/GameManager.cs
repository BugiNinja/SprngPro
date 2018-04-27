using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager Manager;

    private ProgressManager progress;
    private PlayerStats stats;
    private PlayerPathMove path;

    public int SaveSlots = 3;
    //public List<int> SaveSlots;

    private void Awake()
    {

        //SaveSlots = new List<int>();
        if (Manager == null)
        {
            DontDestroyOnLoad(gameObject);
            Manager = this;
        }
        else if (Manager != this)
        {
            Destroy(gameObject);
        }
    }

    public void NewGameInit()
    {
        GameData data = new GameData();

        data.HealthCurrent = 3;
        data.LastWayPointId = 0;
    }

    public void Save(int n)
    {
        //progress = GameObject.Find("ProgressManager").GetComponent<ProgressManager>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        path = GameObject.Find("Player").GetComponent<PlayerPathMove>();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/gameInfo_" + n + ".out", FileMode.Create); //Tiedostopääte kirjataan tdd:iin;

        GameData data = new GameData();

        //data.Triggers = Triggers;
        data.LastWayPointId = path.GetLastWayPointId();
        data.HealthCurrent = stats.GetHealth();

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load(int n)
    {
        //progress = GameObject.Find("ProgressManager").GetComponent<ProgressManager>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        path = GameObject.Find("Player").GetComponent<PlayerPathMove>();

        if (File.Exists(Application.persistentDataPath + "/gameInfo_" + n + ".out"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/gameInfo_" + n + ".out", FileMode.Open);

            GameData data = bf.Deserialize(file) as GameData;
            file.Close();

            //Triggers = data.Triggers;
            path.LastWayPointId = data.LastWayPointId;
            stats.HealthCurrent = data.HealthCurrent;
        }
    }

    public bool IsSaveSlot()
    {

        for (int i = 0; i < SaveSlots; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/gameInfo_" + i + ".out"))
            {
                return true;
            }
        }
        

        Debug.Log(IsSaveSlot());
        return false;
    }
}

[Serializable]
class GameData
{
    //esim. public float health;
    //public bool[] Triggers;
    public int LastWayPointId;
    public int HealthCurrent;
}
