using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMushroom : MonoBehaviour
{

    [SerializeField] private ScriptableObjectMushroom mushroom;
    public ItemMushroom _mushroom;
    public MushroomRarity.Rarity rarity;

    public ScriptableObjectMushroom GetOriginalMushroom()
    {
        return mushroom;
    }
    private void Start()
    {
        _mushroom = ItemMushroom.CreateInstance<ItemMushroom>();
        _mushroom.Model = mushroom.Model;
        _mushroom.quality = (int)Random.Range(mushroom.minQuality, mushroom.maxQuality);
        _mushroom.costByQuality = mushroom.costByQuality;
        _mushroom.rarity = rarity;
        _mushroom.icon = mushroom.icon;
        _mushroom.mushroomName = mushroom.mushroomName;
    }

    
}
