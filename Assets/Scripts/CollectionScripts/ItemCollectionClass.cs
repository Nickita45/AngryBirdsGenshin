using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Collection", order = 1)]
public class ItemCollectionClass : ScriptableObject
{
   public string nameCharacter; 
   public ElementIconClass.elementTypes elementCharacter;
   public Sprite spriteCharacter;
}
