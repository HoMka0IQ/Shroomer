using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemtaker : MonoBehaviour
{
    Collider[] Items;
    public LayerMask ItemLayer;
    public Basket basket;

    GameObject item;
    bool CheckItemAroundPlayer()
    {
        Items = Physics.OverlapSphere(transform.position, 3, ItemLayer);

        if (Items.Length > 0)
            return true;
        else
        {
            Debug.Log("No one item around player");
            return false;
        }

    }
    public void TakeItemBtn()
    {
        CoolDown.Instance.SetCD(2, TryTakeItem);
    }
    void TryTakeItem()
    {
        if (CheckItemAroundPlayer() && basket.CanAddMushroom())
        {
            item = Items[Random.Range(0, Items.Length)].gameObject;
            Item3DViewer.instance.OpenItemViewer();
            Item3DViewer.instance.SetData(item.GetComponent<BaseMushroom>()._mushroom);
            Destroy(item);
        }
        else
        {
            Debug.Log("No one item around player or basket is full");
        }
    }


}
