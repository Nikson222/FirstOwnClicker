using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    private static string defaultPath = $"{Path.Combine(Application.persistentDataPath, "Saves")}";

    public static void SaveJson(object item, string path, string itemName)
    {
        JsonSerializer serializer = new JsonSerializer();

        serializer.Formatting = Formatting.Indented;

        string finalPath = Path.Combine(defaultPath, path);

        Directory.CreateDirectory(finalPath);

        using (StreamWriter sw = new StreamWriter(Path.Combine(finalPath, itemName)))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            writer.Formatting = Formatting.Indented;

            serializer.Serialize(writer, item);
        }
    }

    //public static void SaveJson(object item, string fullPath)
    //{
    //    JsonSerializer serializer = new JsonSerializer();

    //    serializer.Formatting = Formatting.Indented;

    //    string finalPath = Path.Combine(defaultPath, fullPath);

    //    Directory.CreateDirectory(finalPath);

    //    using (StreamWriter sw = new StreamWriter(finalPath))
    //    using (JsonWriter writer = new JsonTextWriter(sw))
    //    {
    //        writer.Formatting = Formatting.Indented;

    //        serializer.Serialize(writer, item);
    //    }

    //    //Убрать
    //    Debug.Log($"Сохранение файла по пути: {fullPath}");
    //}

    public static T LoadJson<T>(string filePath)
    {
        string finalPath = Path.Combine(defaultPath, filePath);

        if (!File.Exists(finalPath))
            return default(T);

        using (StreamReader file = File.OpenText(finalPath))
        {
            JsonSerializer serializer = new JsonSerializer();

            return (T)serializer.Deserialize(file, typeof(T));
        }
    }
}
