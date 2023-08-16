using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item3DViewer : MonoBehaviour, IDragHandler
{
    GameObject item;
    public ItemMushroom MushroomData;
    InsectSpawner insectSpawner;
    public GameObject PlaceForSpawnItem;
    public GameObject UI;

    public Image qualityFillAmount;
    public TMP_Text qualiteText; 

    float yRot;
    float xRot;
    public float smooth;

    public static Item3DViewer instance;

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
    public void SetData(ItemMushroom MushroomData)
    {
        this.MushroomData = MushroomData;
        SpawnObjectToView();
    }

    public void SpawnObjectToView()
    {
        item = Instantiate(MushroomData.Model, PlaceForSpawnItem.transform);
        item.transform.position = PlaceForSpawnItem.transform.position;
        item.transform.rotation = PlaceForSpawnItem.transform.rotation;
        item.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        item.AddComponent<MeshCollider>();
        insectSpawner.SpawnInsectOnMushroom(item, Random.Range(2,5));
        xRot = 0;
        yRot = 0;
        SetMushroomPos();
    }

    public void CloseItemViewer()
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
            qualityFillAmount.fillAmount = MushroomData.quality / 100;
            qualiteText.text = (int)MushroomData.quality + "";
        }
    }
    public void DestroyItem()
    {
        CloseItemViewer();
    }
    public void SaveItem()
    {
        Basket.instance.AddMushroom(MushroomData);
        DestroyItem();
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
