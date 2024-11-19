using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{

    [Header("Save and Load Options")]
    [Space(10)]
    public bool autoLoad; //option to auto-load data
    public bool autoSave; //option to auto save

    [Header("Player Properties to Save and Load")]
    [Space(10)]
    public PlayerProperties playerProperties;

    private string filePath; //file path to save and load data

    #region Setup and Initialization
    private void Awake()
    {
        //set the file path to the persistent data path
        filePath = Application.persistentDataPath + "/playerData.json";

        //Initialize with default data if no existing data is loaded
        if (playerProperties == null)
        {
            playerProperties = new PlayerProperties();
        }

        // Auto-load data if the option is enabled
        if (autoLoad)
        {
            LoadData();
        }
    }
    #endregion

    #region Save Load Clear Data
    public void LoadData()
    {
        //check if file exists
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerProperties = JsonUtility.FromJson<PlayerProperties>(json);
            Debug.Log("Data loaded from " + filePath);
        }
        else
        {
            Debug.LogWarning("Save file not found at " + filePath);
        }
    }

    public void SaveData()
    {

    }

}