using UnityEngine;
using System;
[Serializable]
public class ElementIconClass
{
        
    public enum elementTypes { Cryo, Hydro, Anemo, Pyro, Geo, Dendro, Electro};
    public elementTypes Types;
    public Sprite sprite;
}