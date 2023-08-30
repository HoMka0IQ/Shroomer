using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Custom/ItemData")]
public class ItemData : ScriptableObject
{
    public Item[] allItem;
}
