using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog", order = 1)]
public class DialogClass : ScriptableObject
{
    public string description;
    [TextArea(3,5)]
    public List<string> dilogue;
}
