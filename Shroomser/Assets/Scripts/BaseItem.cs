using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] protected Item mushroom;
    private Item _mushroom;
    public Item GetItemMushroom()
    {
        return _mushroom;
    }
    private void Awake()
    {
        _mushroom = Instantiate(mushroom);
        _mushroom.currentQuality = (int)Random.Range(1, 100);
        SetSizeByQouality();
    }

    protected virtual void SetSizeByQouality()
    {
        float Ran = (GetItemMushroom().currentQuality / 100) / 2;
        float randomSize = 0.75f + Ran;
        gameObject.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
}
