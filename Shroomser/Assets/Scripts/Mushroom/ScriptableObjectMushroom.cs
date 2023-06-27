using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObkectMushroom", menuName = "Custom/Mushroom")]
public class ScriptableObjectMushroom : ScriptableObject
{
    public GameObject Model;
    public float maxQuality;
    public float minQuality;
    public float costByQuality;
    public MushroomRarity.Rarity rarity;
}
