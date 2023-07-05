using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScrollViewContent : MonoBehaviour
{
    RectTransform rectTransform;
    GridLayoutGroup gridLayout;
    public Basket basket;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
    }

    private void Update()
    {
        SetHeight();
    }
    public void SetHeight()
    {
        if (basket.mushroomsInBasket.Count == 0)
        {
            return;
        }
        Debug.Log("ss");
        rectTransform.sizeDelta = new Vector2(0, (gridLayout.cellSize.y + gridLayout.spacing.y) * basket.mushroomsInBasket.Count);
    }
}
