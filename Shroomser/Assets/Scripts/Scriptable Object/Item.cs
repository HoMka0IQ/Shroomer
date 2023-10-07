using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObjectItem", menuName = "Custom/Item")]
public class Item : ScriptableObject
{
    public ItemType.Type itemType;
    public string itemName;
    public Sprite icon;
    public GameObject Model;
    public GameObject Prefab;
    [HideInInspector]public float currentQuality;
    public float costByQuality;
    public MushroomRarity.Rarity rarity;
    public ModelSize.Size size;

    public void IncreaseQuality(int number)
    {
        currentQuality += number;
        currentQuality = Mathf.Clamp(currentQuality, 1, 100);
    }

    public int GetItemCost()
    {
        float cost = costByQuality * currentQuality;
        return Mathf.RoundToInt(cost);
    }
}
