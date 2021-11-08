using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance;
    //public Keybindings bindings;

    public Player player;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/game_save/player_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/player_data");
        }
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/game_save/player_data/player_save.json");
        var json = JsonUtility.ToJson(player);

        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame() {

        if (!Directory.Exists(Application.persistentDataPath + "/game_save/player_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/player_data");
        }
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_save/player_data/player_save.json"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_save/player_data/player_save.json", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), player);

            file.Close();
        }

    }
}
