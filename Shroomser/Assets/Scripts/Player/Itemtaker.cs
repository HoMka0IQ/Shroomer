using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemtaker : MonoBehaviour
{
    Collider[] Items;
    public LayerMask ItemLayer;
    public Basket basket;
    public GameObject inHand;
    bool isInHand;

    GameObject item;
    GameObject box;

    public AudioSource mushroomSound;
    bool CheckItemAroundPlayer(LayerMask layer)
    {
        Items = Physics.OverlapSphere(transform.position, 3, layer);

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
        if (isInHand == false)
        {
            CoolDown.Instance.SetCD(1, TryTakeItem);
        }
        else
        {
            CoolDown.Instance.SetCD(1, DropBox);
        }
        
    }
    void TryTakeItem()
    {
        if (CheckItemAroundPlayer(LayerMask.GetMask("Items")) && basket.CanAddMushroom())
        {
            item = Items[Random.Range(0, Items.Length)].gameObject;
            Item3DViewer.instance.OpenItemViewer();
            Item3DViewer.instance.SetData(item.GetComponent<BaseMushroom>().GetItemMushroom());
            mushroomSound.Play();

            Destroy(item);
        }
        else if (CheckItemAroundPlayer(LayerMask.GetMask("BoxItem")))
        {
            box = Items[Random.Range(0, Items.Length)].gameObject;
            PickUpBox();
        }
        else
        {
            Debug.Log("No one item around player or basket is full");
        }
    }

    void PickUpBox()
    {
        box.GetComponent<BoxCollider>().enabled = false;
        Rigidbody _rb = box.GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _rb.isKinematic = true;
        box.transform.position = inHand.transform.position;
        box.transform.SetParent(inHand.transform);
        box.transform.rotation = inHand.transform.rotation;
        isInHand = true;
        Movement.instance.DecreaceSpeed(30);
        Movement.instance.Animator.SetBool("InHand", true);
    }
    void DropBox()
    {
        box.transform.SetParent(null);
        box.GetComponent<BoxCollider>().enabled = true;
        Rigidbody _rb = box.GetComponent<Rigidbody>();
        _rb.useGravity = true;
        _rb.isKinematic = false;
        box = null;
        isInHand = false;
        Movement.instance.IncreaceSpeed(30);    
        Movement.instance.Animator.SetBool("InHand", false);
    }
}
