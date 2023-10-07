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
    Item item;
    public void SetData(Item mushroom)
    {
        item = mushroom;
        mushroomName.text = mushroom.itemName;
        cost.text = mushroom.GetItemCost() + "<sprite=3>";
        icon.sprite = mushroom.icon;
    }

    public void deleteItem()
    {
        InventoryManager.instance.DeleteItem(item);
    }
}
