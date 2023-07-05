using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public TMP_Text mushroomName;
    public TMP_Text cost;
    public Image icon;
    public void SetData(ItemMushroom mushroom)
    {
        mushroomName.text = mushroom.mushroomName;
        cost.text = "cost: " + mushroom.costByQuality * mushroom.quality;
        icon.sprite = mushroom.icon;
    }
}
