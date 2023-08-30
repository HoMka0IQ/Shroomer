using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMushroom : BaseMushroom
{
    public ItemData mushroomData;
    private void Awake()
    {
        mushroom = mushroomData.allItem[Random.Range(0, mushroomData.allItem.Length)];
    }
}
