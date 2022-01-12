using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public GameObject[] levels;
    
    public void Start()
    {
        
        Dictionary<string,InfoData.Level> _levels = DataHandler.Instance.userdata.levels;
        
        int countCompletedLevels = _levels.Count;
        
        //if()
        ///print(_levels["1_1"].Rating);
        for(int i=0;i<levels.Length;i++)
        {
            int category = 1;
            int number_lvl = int.Parse(levels[i].name.Replace("LevelObject","").ToString());
            levels[i].GetComponentInChildren<TextMeshProUGUI>().text = number_lvl.ToString();
            string key = category+"_"+number_lvl;
            /*if(i == 2 && !DataHandler.Instance.userdata.isXiao)
            {
                break;
            }*/
            if(_levels.ContainsKey(key))
            {
                
                levels[i].GetComponentsInChildren<Image>(true)[5].gameObject.SetActive(false);
                int count_stars = _levels[key].countStars;
                for(int j=3;j>=(count_stars+1);j--)
                {
                    levels[i].GetComponentsInChildren<Image>(true)[j].gameObject.SetActive(false);
                }
                levels[i].GetComponent<Button>().onClick.AddListener(() => startLevel(key));
            }
            else
            {
                if(countCompletedLevels == i )
                {
                    if(i == 2 && !DataHandler.Instance.userdata.isXiao)
                    {}
                    else
                    {
                        levels[i].GetComponentsInChildren<Image>(true)[5].gameObject.SetActive(false);
                        levels[i].GetComponent<Button>().onClick.AddListener(() => startLevel(key));
                    }
                }
                else
                    levels[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                for(int j=3;j>0;j--)
                {
                    levels[i].GetComponentsInChildren<Image>(true)[j].gameObject.SetActive(false);
                }
            }
        }
        
    }
    public void startLevel(string number)
    {
        SceneManager.LoadScene("Level"+number);
    }
    public void setDialogFirst()
    {
        if(DataHandler.Instance.userdata.dialogs[0] == false)
        {
            DialogController.Instance.setCurrentDialog(0);
            DataHandler.Instance.userdata.dialogs[0] = true;
            DataHandler.Instance.SaveData();
        }
        else if(DataHandler.Instance.userdata.dialogs[4] == false && DataHandler.Instance.userdata.isXiao && DataHandler.Instance.userdata.levels.Count == 2)
        {
            DialogController.Instance.setCurrentDialog(4);
            DataHandler.Instance.userdata.dialogs[4] = true;
            DataHandler.Instance.SaveData();
        }
    }
}
