using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    private static SavedData instance;

    private Dictionary<string, bool> _buttonStates = new Dictionary<string, bool>();

    private static string path = $"SavedData";
    private static string fileName = $"{"DataSave.json"}";
    private static string fullPath = $"{Path.Combine(path, fileName)}";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Load();
    }

    public void Save()
    {
        var rawData = GenerateData();

        SaveManager.SaveJson(rawData, path, fileName);
    }

    public void Load()
    {
        var rawData = SaveManager.LoadJson<RawData>(fullPath);

        if (rawData == null)
            return;

        _buttonStates = rawData._buttonStates;
    }

    public static void SetButtonState(string buttonName, bool buttonState)
    {
        if (instance._buttonStates.ContainsKey(buttonName))
            instance._buttonStates[buttonName] = buttonState;
        else
            instance._buttonStates.Add(buttonName, buttonState);

        instance.Save();
    }

    public static bool GetButtonState(string buttonName)
    {
        if (instance._buttonStates.ContainsKey(buttonName))
            return instance._buttonStates[buttonName];
        else
            return false;
    }

    public static bool GetButtonState(string buttonName, bool defaultValue)
    {
        if (instance._buttonStates.ContainsKey(buttonName))
            return instance._buttonStates[buttonName];
        else
            return defaultValue;
    }

    private RawData GenerateData()
    {
        var rawData = new RawData();

        rawData._buttonStates = _buttonStates;

        return rawData;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}

public class RawData
{
    public Dictionary<string, bool> _buttonStates = new Dictionary<string, bool>();
}
