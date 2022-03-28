using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Quest", menuName = "Quests", order = 1)]
public class QuestClass
{
    public string questName;
    public string location;
    public string typeQuest; //enum!!!!!!
    public string targetQuestDescription;
    public int countTargetQuest = 1;
    public string description;
    //List rewards
    //List enemies
    //List levels
}
