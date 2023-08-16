using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMushroom : MonoBehaviour
{

    [SerializeField] protected ScriptableObjectMushroom mushroom;
    private ItemMushroom _mushroom;

    public ScriptableObjectMushroom GetOriginalMushroom()
    {
        return mushroom;
    }
    public ItemMushroom GetItemMushroom()
    {
        return _mushroom;
    }
    private void Start()
    {
        _mushroom = ItemMushroom.CreateInstance<ItemMushroom>();
        _mushroom.Model = mushroom.Model;
        _mushroom.quality = (int)Random.Range(mushroom.minQuality, mushroom.maxQuality);
        _mushroom.costByQuality = mushroom.costByQuality;
        _mushroom.rarity = mushroom.rarity;
        _mushroom.icon = mushroom.icon;
        _mushroom.mushroomName = mushroom.mushroomName;
    }

    
}
