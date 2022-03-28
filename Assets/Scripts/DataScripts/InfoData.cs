using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InfoData
{
    
    public Dictionary<string,Level> levels = new  Dictionary<string,Level>();
    public List<bool> dialogs = new List<bool>();//new List<bool>() {false,false,false,
                                //                false,false,false};
    public bool isXiao = false;
    [Serializable]
    public class Level
    {
        public string nameLevel = "";//1-1
        public int Rating = 0;
        public int countStars = 0;//if 1 its completed
    }
    public string[] squad = {"Tartaglia","Tartaglia","Tartaglia"};
    
    public Dictionary<string,int> collection = new Dictionary<string, int>(); //nameCharacter:count
    
}
