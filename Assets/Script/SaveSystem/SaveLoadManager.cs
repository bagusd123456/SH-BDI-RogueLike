using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    private void Start()
    {
        //gameObjects = FindObjectsOfType<GameObject>();
    }

    [SerializeField] private static PlayerData playerData;

    [ContextMenu("Save")]
    public void SaveToJSON()
    {
        string convertPlayerData = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerData.dat", convertPlayerData);
        Debug.Log("Saved to: " + Application.persistentDataPath + "/PlayerData.dat");

    }

    [ContextMenu("Load")]
    public void LoadFromJSON()
    {
        string savedData = System.IO.File.ReadAllText(Application.persistentDataPath + "/PlayerData.dat");
        playerData = JsonUtility.FromJson<PlayerData>(savedData);
        Debug.Log("Loaded: " + Application.persistentDataPath + "/PlayerData.dat");
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public string description;
}
