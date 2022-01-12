using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController: MonoBehaviour{

    public Button buttonBanner;
    void Start()
    {
        SetBannerButton();
    }
    public void SetBannerButton()
    {
        if(DataHandler.Instance.userdata.levels.Count == 2 && !DataHandler.Instance.userdata.isXiao)
            buttonBanner.gameObject.SetActive(true);
        else
            buttonBanner.gameObject.SetActive(false);
    }
    public static UIController Instance
    {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType(typeof(UIController)) as UIController;
 
             return instance;
         }
         set
         {
             instance = value;
         }
    }
    private static UIController instance;
}