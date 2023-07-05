using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slot;
    public Transform content;
    public Basket basket;
    List<GameObject> slots = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenInventory()
    {
        LoadInventory(basket.mushroomsInBasket);
    }

    void LoadInventory(List<ItemMushroom> items)
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
        }
    }
}
