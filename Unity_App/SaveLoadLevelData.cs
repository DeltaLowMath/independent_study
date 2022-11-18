using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadLevelData {

    public static void SaveData (SkillLevelIndex data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/skillLevel.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData levelData = new LevelData(data);

        formatter.Serialize(stream, levelData);
        stream.Close();
    }

    public static LevelData LoadData()
    {
        string path = Application.persistentDataPath + "/skillLevel.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData levelData = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            return levelData;
        }
        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}