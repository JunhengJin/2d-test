using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManager : MonoBehaviour
{
    public Inventory myInventroy;
    public Item thisItem;

    public void SaveGame()
    {
        Debug.Log(Application.persistentDataPath);

        if (!Directory.Exists((Application.persistentDataPath + "/game_SaveData")))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveData/inventory.txt");
        var json = JsonUtility.ToJson(myInventroy);
        formatter.Serialize(file,json);
        file.Close();
        
        BinaryFormatter formatter2 = new BinaryFormatter();
        FileStream file2 = File.Create(Application.persistentDataPath + "/game_SaveData/inventory2.txt");
        var json2 = JsonUtility.ToJson(thisItem);
        formatter2.Serialize(file2,json2);
        file2.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/inventory.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveData/inventory.txt",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),myInventroy);
            file.Close();
        }
        BinaryFormatter bf2 = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/inventory2.txt"))
        {
            FileStream file2 = File.Open(Application.persistentDataPath + "/game_SaveData/inventory2.txt",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf2.Deserialize(file2),thisItem);
            file2.Close();
        }
    }
    
}
