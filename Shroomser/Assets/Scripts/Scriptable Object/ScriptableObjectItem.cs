using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObjectItem", menuName = "Custom/Item")]
public class ScriptableObjectItem : ScriptableObject
{
    public ItemType.Type itemType;
    public string itemName;
    public Sprite icon;
    public GameObject Model;
    public GameObject Prefab;
    public float maxQuality;
    public float minQuality;
    public float costByQuality;
    public MushroomRarity.Rarity rarity;
    public ModelSize.Size size;
}
