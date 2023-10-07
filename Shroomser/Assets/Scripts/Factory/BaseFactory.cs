using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BaseFactory : MonoBehaviour
{
    public ItemType.Type WhichItemCanTaked;

    public TMP_Text number;
    protected Basket basket;

    public int MaxCount;
    public List<Item> ItemInFactory;

    public GameObject boxPrefab;
    public Transform SpawnBoxPosition;
    [HideInInspector]public bool isWorking = false;
    public float timerInSeconds;
    [HideInInspector]public float _currentTimer = 0;
   
    private void Start()
    {
        basket = Basket.instance;
        TextReload();
    }

    private void Update()
    {
        if (isWorking)
        {
            _currentTimer += Time.deltaTime;
            TextReload();
            if (_currentTimer >= timerInSeconds)
            {
                InstantiateMushroomBox();
                isWorking = false;
                _currentTimer = 0;
            }
        }
    }
    public void InstantiateMushroomBox()
    {
        GameObject box = Instantiate(boxPrefab, SpawnBoxPosition.position, Quaternion.identity);
        SaveLoadBoxes.instance.AddBoxes(box.GetComponent<BoxManager>());
        float cost = 0;
        for (int i = 0; i < ItemInFactory.Count; i++)
        {
            cost += ItemInFactory[i].GetItemCost();
        }
        box.GetComponent<BoxManager>().cost = (int)cost;
        ItemInFactory.Clear();
        TextReload();
    }
    public void TextReload()
    {
        if (ItemInFactory.Count >= MaxCount)
        {
            number.text = FormatTime(timerInSeconds - _currentTimer);
        }
        else
        {
            number.text = "(" + ItemInFactory.Count + "/" + MaxCount + ")<sprite=5>";
        }
        
    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    public void AddItemInFactory()
    {
        StartCoroutine(AddItem());
    }
    IEnumerator AddItem()
    {
        for (int i = basket.mushroomsInBasket.Count - 1; i > -1; i--)
        {
            Debug.Log(i);
            Debug.Log(basket.mushroomsInBasket.Count);
            if (basket.mushroomsInBasket[i].itemType == ItemType.Type.NotSelected)
            {
                Debug.LogError("Item type not selected, please select item tyme in the Scriptable object 'ScriptableObjectItem'");
                yield break;
            }
            if (basket.mushroomsInBasket[i].itemType == WhichItemCanTaked && MaxCount > ItemInFactory.Count)
            {
                ItemInFactory.Add(basket.mushroomsInBasket[i]);
                basket.mushroomsInBasket.RemoveAt(i);
                TextReload();
                if (MaxCount == ItemInFactory.Count)
                {
                    isWorking = true;
                }

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
