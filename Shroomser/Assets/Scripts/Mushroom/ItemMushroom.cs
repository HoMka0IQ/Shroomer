using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemMushroom : ScriptableObject
{
    public string mushroomName;
    public Sprite icon;
    public GameObject Model;
    public float quality;
    public float costByQuality;
    public MushroomRarity.Rarity rarity;

    public void IncreaseQuality(int number)
    {
        quality += number;
    }
}
