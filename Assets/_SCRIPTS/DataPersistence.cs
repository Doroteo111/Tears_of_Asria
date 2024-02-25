 using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    [SerializeField] private Player player; //get acces to the player'script

    private const string SAVE_FILE_PATH = "/save.json";

    private void Update()
    {
       
    }

    public void SaveJson() 
    {
        Debug.Log("Saved with JSON");

        int totalGems=player.GetTotalGems();
        bool hasBlueKey=player.HasGetBlueKeys();

        SaveData saveData = new SaveData
        {
            gems = totalGems,
            hasBlueKey = hasBlueKey
            
        };

        string savedDataJson=JsonUtility.ToJson(saveData); //the jsonification 
                                                           //from unity object to Json string

        File.WriteAllText(Application.dataPath + SAVE_FILE_PATH, savedDataJson);
    } 

    public void LoadJson()
    { 
        Debug.Log("Loaded with JSON");
        if(File.Exists(Application.dataPath+SAVE_FILE_PATH))
        {
            string savedDataString=File.ReadAllText(Application.dataPath + SAVE_FILE_PATH); //from Json string to unity object

            SaveData saveData = JsonUtility.FromJson<SaveData>(savedDataString);

            player.SetTotalGems(saveData.gems);
            //player.HasGetBlueKeys(saveData.hasBlueKey); 
        }
        else
        {
            //supposedly we must never fell here
            Debug.LogError("No eror file");
        }
    }
}
