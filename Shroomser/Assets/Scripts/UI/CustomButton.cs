using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class CustomButton : MonoBehaviour ,IPointerDownHandler ,IPointerUpHandler
{
    Image image;
    RectTransform rectTransform;
    public UnityEvent action;

    public float scaleSize = 1.1f;

    [Header("Sprite changer")]
    public Sprite OffSprite;
    public Sprite OnSprite;
    public GameObject window;


    private void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.localScale = rectTransform.localScale / scaleSize;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform.localScale = rectTransform.localScale * scaleSize;
        action.Invoke();

        if (OffSprite == null || window == null)
        {
            return;
        }
        OpenCloseSprite();
    }

    public void OpenCloseSprite()
    {
        image.sprite = window.activeSelf ? OnSprite : OffSprite;
    }


}
