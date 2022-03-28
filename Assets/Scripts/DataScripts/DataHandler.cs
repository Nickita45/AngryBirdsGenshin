using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class DataHandler : MonoBehaviour
{
    public InfoData userdata = new InfoData();
    void Awake()
    {
        DataHandler[] objs = GameObject.FindObjectsOfType<DataHandler>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        //PlayerPrefs.DeleteAll();
        LoadSaveData();
        print(userdata.levels.Count);

        
        

    }
    public void SaveData()
    {

        string saveJson = JsonConvert.SerializeObject(userdata);
        print(saveJson);
        PlayerPrefs.SetString("playerStat",saveJson);
        PlayerPrefs.Save();
        
    }
    public void LoadSaveData()
    {
        if(PlayerPrefs.HasKey("playerStat"))
        {

            string saveJson = PlayerPrefs.GetString("playerStat");
            userdata = JsonConvert.DeserializeObject<InfoData>(saveJson);
        }
        else
        {
            userdata.dialogs = Utility.ToList<bool>(ArrayList.Repeat(false,6));
            userdata.collection.Add("Tartaglia",3);
            userdata.collection.Add("Xiao",1);
            SaveData();
            
        }
    }
    public static DataHandler Instance
    {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType(typeof(DataHandler)) as DataHandler;
 
             return instance;
         }
         set
         {
             instance = value;
         }
    }
    private static DataHandler instance;
}
