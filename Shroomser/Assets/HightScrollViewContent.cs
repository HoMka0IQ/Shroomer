using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScrollViewContent : MonoBehaviour
{
    RectTransform rectTransform;
    GridLayoutGroup gridLayout;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
    }

    public void SetHeight()
    {
        if (transform.childCount == 0)
        {
            return;
        }
        rectTransform.sizeDelta = new Vector2(0, (transform.GetChild(0).GetComponent<RectTransform>().rect.height * transform.childCount) + gridLayout.spacing.y);
    }
}
