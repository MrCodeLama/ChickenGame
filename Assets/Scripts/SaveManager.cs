using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public int currentChicken;
    public int money;
    public bool[] chickenUnlocked = new bool[3] { true, false, false};
    public int highScore;
        
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            money = data.money;
            currentChicken = data.currentChicken;
            chickenUnlocked = data.chickenUnlocked;
            highScore = data.highScore;

            if (data.chickenUnlocked ==  null)
                chickenUnlocked = new bool[3] { true, false, false,};
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();
        
        data.money = money;
        data.currentChicken = currentChicken;
        data.chickenUnlocked = chickenUnlocked;
        data.highScore = highScore;
        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    public int currentChicken;
    public int money;
    public bool[] chickenUnlocked;
    public int highScore;
}