using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item3DViewer : MonoBehaviour, IDragHandler
{
    GameObject item;
    public Item MushroomData;
    InsectSpawner insectSpawner;
    public GameObject PlaceForSpawnItem;
    public GameObject UI;

    public Image qualityFillAmount;
    public Transform textPosition;
    public TMP_Text qualityText;
    public TMP_Text costText;

    float yRot;
    float xRot;
    public float smooth;

    public static Item3DViewer instance;

    public AudioSource takeSound;
    public AudioSource DropSound;

    void Start()
    {
        instance = GetComponent<Item3DViewer>();
        insectSpawner = GetComponent<InsectSpawner>();
        CloseItemViewer();
    }

    private void Update()
    {
        ShowQuality();
    }

    public void OpenItemViewer()
    {
        if (item != null)
        {
            Destroy(item);
        }
        WindowsManager.instance.ClostAllWindows();
        UI.SetActive(true);
    }
    public void SetData(Item MushroomData)
    {
        this.MushroomData = MushroomData;
        SpawnObjectToView();
    }
    float GetModelZise()
    {
        switch (MushroomData.size)
        {
            case ModelSize.Size.Default:
                return 1f;
            case ModelSize.Size.Big:
                return 0.75f;
            case ModelSize.Size.Small:
                return 1.25f;

            default:
                return 1f;
        }
    }
    public void SpawnObjectToView()
    {
        item = Instantiate(MushroomData.Model, PlaceForSpawnItem.transform);
        item.transform.localScale *= GetModelZise();
        item.transform.position = PlaceForSpawnItem.transform.position;
        item.transform.rotation = PlaceForSpawnItem.transform.rotation;
        item.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        item.AddComponent<MeshCollider>();
        insectSpawner.SpawnInsectOnMushroom(item, Random.Range(2,5));
        xRot = 0;
        yRot = 0;
        SetMushroomPos();
    }

    void CloseItemViewer()
    {
        if (item != null)
        {
            Destroy(item);
        }
        UI.SetActive(false);
    }
    public void ShowQuality()
    {
        if (MushroomData != null)
        {
            qualityFillAmount.fillAmount = MushroomData.currentQuality / 100;
            float fillAmount = qualityFillAmount.fillAmount;
            textPosition.localPosition = new Vector3(0, qualityFillAmount.fillAmount * qualityFillAmount.rectTransform.rect.height, 0);
            qualityText.text = (int)MushroomData.currentQuality + "%";
            costText.text = MushroomData.GetItemCost() + "<sprite=3>";
        }
    }
    public void DestroyItem()
    {
        CloseItemViewer();
        DropSound.Play();
    }
    public void SaveItem()
    {
        Basket.instance.AddMushroom(MushroomData);
        CloseItemViewer();
        takeSound.Play();
    }
    public void OnDrag(PointerEventData eventData)
    {
        xRot -= eventData.delta.y / smooth;
        yRot -= eventData.delta.x / smooth;
        SetMushroomPos();
    }
        

    void SetMushroomPos()
    {
        if (xRot > 20)
        {
            xRot = 20;
        }
        if (xRot < -20)
        {
            xRot = -20;
        }
        Vector3 yRotVector = new Vector3(0f, yRot, 0f);
        Vector3 xRotVector = new Vector3(-xRot + 60, 0f, 0f);
        item.transform.localEulerAngles = yRotVector;
        PlaceForSpawnItem.transform.eulerAngles = xRotVector;
    }
}
