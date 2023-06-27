using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMushroom : ScriptableObject
{
    public GameObject Model;
    public float quality;
    public float costByQuality;
    public MushroomRarity.Rarity rarity;

    public void IncreaseQuality(int number)
    {
        quality += number;
    }
}
