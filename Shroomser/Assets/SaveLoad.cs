using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    public Basket basket;

    private void Awake()
    {
        loadSistem();
        StartCoroutine(SaveData());
    }

    public void loadSistem()
    {
        if (PlayerPrefs.HasKey("MaxCountInBasket"))
        {
            basket.maxCount = PlayerPrefs.GetInt("MaxCountInBasket");
            for (int i = 0; i < PlayerPrefs.GetInt("CountInBasket"); i++)
            {
                ItemMushroom mushroom = ItemMushroom.CreateInstance<ItemMushroom>();
                mushroom.quality = PlayerPrefs.GetFloat("MushroomQuality" + i);
                mushroom.costByQuality = PlayerPrefs.GetFloat("costByQuality" + i);
                basket.AddMushroom(mushroom);
                
            }
        }
        
    }

    public void SaveSistem()
    {
        PlayerPrefs.SetInt("MaxCountInBasket", basket.maxCount);
        PlayerPrefs.SetInt("CountInBasket", basket.mushroomsInBasket.Count);
        for (int i = 0; i < basket.mushroomsInBasket.Count; i++)
        {
            PlayerPrefs.SetFloat("MushroomQuality" + i, basket.mushroomsInBasket[i].quality);
            PlayerPrefs.SetFloat("costByQuality" + i, basket.mushroomsInBasket[i].costByQuality);
        }
    }


    IEnumerator SaveData()
    {
        while (true)
        {
            SaveSistem();
            yield return new WaitForSeconds(3f);
        }
    }
    private void OnApplicationQuit()
    {
        SaveSistem();
        Debug.Log("sss");
    }

    public void DeleteAllKey()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("Money");
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(SaveLoad))]
public class DeleteAllKey : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SaveLoad test = (SaveLoad)target;
        if (GUILayout.Button("Delete All Save"))
        {
            test.DeleteAllKey();
        }

    }
}
#endif

