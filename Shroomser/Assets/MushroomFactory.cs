using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MushroomFactory : MonoBehaviour
{
    public TMP_Text number;
    Basket basket;

    public int MaxCount;
    public List<ItemMushroom> mushroomsInFactory;

    public GameObject boxPrefab;
    public Transform SpawnBoxPosition;
    [HideInInspector]public bool isWorking = false;
    public float timerInSeconds;
    float _currentTimer = 0;
   
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
        Instantiate(boxPrefab, SpawnBoxPosition.position, Quaternion.identity);
        mushroomsInFactory.Clear();
        TextReload();
    }
    public void TextReload()
    {
        number.text = mushroomsInFactory.Count + "/" + MaxCount;
    }
    public void AddMushroomInFactory()
    {
        StartCoroutine(AddMushroom());
    }

    IEnumerator AddMushroom()
    {
        while (MaxCount > mushroomsInFactory.Count && basket.mushroomsInBasket.Count > 0)
        {
            yield return new WaitForSeconds(0.1f);
            mushroomsInFactory.Add(basket.mushroomsInBasket[basket.mushroomsInBasket.Count - 1]);
            basket.mushroomsInBasket.RemoveAt(basket.mushroomsInBasket.Count - 1);
            TextReload();
            if (MaxCount == mushroomsInFactory.Count)
            {
                isWorking = true;
            }
        }
    }


}
