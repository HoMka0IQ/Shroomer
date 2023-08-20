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
    private void Awake()
    {
        _mushroom = ItemMushroom.CreateInstance<ItemMushroom>();
        _mushroom.Model = mushroom.Model;
        _mushroom.quality = (int)Random.Range(mushroom.minQuality, mushroom.maxQuality);
        _mushroom.costByQuality = mushroom.costByQuality;
        _mushroom.rarity = mushroom.rarity;
        _mushroom.size = mushroom.size;
        _mushroom.icon = mushroom.icon;
        _mushroom.mushroomName = mushroom.mushroomName;
        SetSizeByQouality();
    }

    protected virtual void SetSizeByQouality()
    {
        float Ran = (GetItemMushroom().quality / 100) / 2;
        Debug.Log(Ran, gameObject);
        float randomSize = 0.75f + Ran;
        gameObject.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
}
