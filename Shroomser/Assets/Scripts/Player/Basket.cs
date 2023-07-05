using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public int maxCount;
    public List<ItemMushroom> mushroomsInBasket;

    public static Basket instance;

    private void Awake()
    {
        instance = GetComponent<Basket>();
    }

    public bool CanAddMushroom()
    {
        if (mushroomsInBasket.Count >= maxCount)
            return false;
        else
            return true;
    }
    public void AddMushroom(ItemMushroom mushroom)
    {
        mushroomsInBasket.Add(mushroom);
        InventoryManager.instance.ReloadInventory();
    }
}
