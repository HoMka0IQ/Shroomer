using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObkectMushroom", menuName = "Custom/Mushroom")]
public class ScriptableObjectMushroom : ScriptableObject
{
    public string mushroomName;
    public Sprite icon;
    public GameObject Model;
    public GameObject Prefab;
    public float maxQuality;
    public float minQuality;
    public float costByQuality;
    public MushroomRarity.Rarity rarity;
}
