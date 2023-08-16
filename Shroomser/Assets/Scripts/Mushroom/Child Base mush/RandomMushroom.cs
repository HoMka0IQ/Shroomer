using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMushroom : BaseMushroom
{
    public MushroomData mushroomData;
    private void Awake()
    {
        mushroom = mushroomData.allMushroom[Random.Range(0, mushroomData.allMushroom.Length)];
    }
}
