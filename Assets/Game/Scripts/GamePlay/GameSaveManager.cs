using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameSaveManager : MonoBehaviour
{
    public Inventory myInventroy;
    public List<Item> thisItem = new List<Item>();

    public void SaveGame()
    {
        ES3AutoSaveMgr.Current.Save();
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
        
        
         for (int i = 0; i < thisItem.Count;i++)
         {
             BinaryFormatter formatter2 = new BinaryFormatter();
             FileStream file2 = File.Create(Application.persistentDataPath + "/game_SaveData/item"+i+".txt");
             var json2 = JsonUtility.ToJson(thisItem[i]);
             formatter2.Serialize(file2,json2);
             file2.Close();
         }
    }

    public void LoadGame()
    {
        ES3AutoSaveMgr.Current.Load();
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/inventory.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveData/inventory.txt",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),myInventroy);
            file.Close();
        }
        for (int i = 0; i < thisItem.Count;i++)
        {
            BinaryFormatter bf2 = new BinaryFormatter();
            if (File.Exists(Application.persistentDataPath + "/game_SaveData/item"+i+".txt"))
            {
                FileStream file2 = File.Open(Application.persistentDataPath + "/game_SaveData/item"+i+".txt",FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf2.Deserialize(file2),thisItem[i]);
                file2.Close();
            }
        }
    }
    
}
