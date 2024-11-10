using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveByJson(string SaveFileName, object data)
    {
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, SaveFileName);

        try {
            File.WriteAllText(path, json);
        } catch (System.Exception) {
            Debug.Log("Fail to save file to " +  path);
        }
    }

    public static T LoadFromJson<T>(string SaveFileName)
    {
        string path = Path.Combine(Application.persistentDataPath, SaveFileName);

        try {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        } catch (System.Exception) {
            Debug.Log("Fail to load file from " +  path);
            return default(T);
        }
    }

    public static void DeleteSaveFile(string SaveFileName)
    {
        string path = Path.Combine(Application.persistentDataPath, SaveFileName);

        try {
            File.Delete(path);
        } catch (System.Exception) {
            Debug.Log("Fail to delete file from " +  path);
        }
    }
}
