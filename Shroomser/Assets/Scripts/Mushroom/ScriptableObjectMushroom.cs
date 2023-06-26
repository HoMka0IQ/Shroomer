using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObkectMushroom", menuName = "Custom/Mushroom")]
public class ScriptableObjectMushroom : ScriptableObject
{
    public GameObject Model;
    public float maxQuality;
    public float minQuality;
    [HideInInspector] public float quality;
    public float costByQuality;
    public MushroomRarity.Rarity rarity;

    private void Awake()
    {
        quality = Random.Range(minQuality, maxQuality);
    }
    public void IncreaseQuality(int number)
    {
        quality += number;
    }    
}
