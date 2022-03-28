using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ElementsSingleton : MonoBehaviour
{
                                                      
    public ElementIconClass[] elementIcons;
    public static ElementsSingleton Instance
    {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType(typeof(ElementsSingleton)) as ElementsSingleton;
 
             return instance;
         }
         set
         {
             instance = value;
         }
    }
    private static ElementsSingleton instance;
    public Sprite searchSpriteByElement(String elementName)
    {
        Sprite sprite = elementIcons[0].sprite;
        for(int i=0;i<elementIcons.Length;i++)
        {
            if(elementIcons[i].Types.ToString() == elementName)
                sprite = elementIcons[i].sprite;
        }
        return sprite;
    }

}