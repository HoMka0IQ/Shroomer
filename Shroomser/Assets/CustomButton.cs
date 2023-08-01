using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class CustomButton : MonoBehaviour ,IPointerDownHandler ,IPointerUpHandler
{
    Image image;
    RectTransform rectTransform;
    public UnityEvent action;

    public Sprite OffSprite;
    public Sprite OnSprite;

    bool isOn = false;
    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.localScale = rectTransform.localScale / 1.2f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform.localScale = rectTransform.localScale * 1.2f;

        isOn = !isOn;
        image.sprite = isOn ? OnSprite : OffSprite;

        action.Invoke();
    }


}
