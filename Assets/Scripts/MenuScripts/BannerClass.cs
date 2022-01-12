using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Banner Item", menuName = "Banner", order = 1)]
public class BannerClass : ScriptableObject
{
    public bool isWeapon = false;
    public Sprite mainPicture;
    public int countStars = 3;
    public string name = "";
}
