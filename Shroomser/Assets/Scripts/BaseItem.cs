using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] protected ScriptableObjectItem mushroom;
    private Item _mushroom;

    public ScriptableObjectItem GetOriginalMushroom()
    {
        return mushroom;
    }
    public Item GetItemMushroom()
    {
        return _mushroom;
    }
    private void Awake()
    {
        _mushroom = Item.CreateInstance<Item>();

        _mushroom.itemType = mushroom.itemType;
        _mushroom.Model = mushroom.Model;
        _mushroom.quality = (int)Random.Range(mushroom.minQuality, mushroom.maxQuality);
        _mushroom.costByQuality = mushroom.costByQuality;
        _mushroom.rarity = mushroom.rarity;
        _mushroom.size = mushroom.size;
        _mushroom.icon = mushroom.icon;
        _mushroom.itemName = mushroom.itemName;
        SetSizeByQouality();
    }

    protected virtual void SetSizeByQouality()
    {
        float Ran = (GetItemMushroom().quality / 100) / 2;
        float randomSize = 0.75f + Ran;
        gameObject.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
}
