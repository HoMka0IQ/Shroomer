using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject slot;
    public Transform content;
    public Basket basket;
    List<GameObject> slots = new List<GameObject>();
    public HightScrollViewContent hightScroll;
    public GameObject InventoryWindow;

    public static InventoryManager instance;

    public TMP_Text slotText;
    private void Awake()
    {
        instance = GetComponent<InventoryManager>();
    }
    public void OpenCloseInventory()
    {
        InventoryWindow.SetActive(!InventoryWindow.activeSelf);
        ReloadInventory();
    }
    public void ReloadInventory()
    {
        LoadInventorySlots(basket.mushroomsInBasket);
    }

    void LoadInventorySlots(List<Item> items)
    {
        if (slots.Count > 0)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                Destroy(slots[i]);
            }
            slots.Clear();
        }
        for (int i = 0; i < items.Count; i++)
        {
            GameObject sl = Instantiate(slot, content);
            Slot slotScript = sl.GetComponent<Slot>();
            slotScript.SetData(items[i]);
            slots.Add(sl);
            slotText.text = slots.Count + "/" + basket.maxCount;
        }
        hightScroll.SetHeight();
    }

    public void DeleteItem(Item item)
    {
        for (int i = 0; i < basket.mushroomsInBasket.Count; i++)
        {
            if (basket.mushroomsInBasket[i] == item)
            {
                basket.mushroomsInBasket.RemoveAt(i);
                ReloadInventory();
                slotText.text = slots.Count + "/" + basket.maxCount;
                return;
            }
        }
    }
}
