using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MushroomFactory : MonoBehaviour
{
    public TMP_Text number;
    public int MaxCount;
    public List<ScriptableObjectMushroom> mushroomsInFactory;
    Basket basket;
    private void Start()
    {
        basket = Basket.instance;
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
        }
    }
}
