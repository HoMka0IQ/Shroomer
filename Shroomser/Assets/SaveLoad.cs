using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    public Basket basket;
    public MushroomData mushroomData;

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
                for (int t = 0; t < mushroomData.allMushroom.Length; t++)
                {
                    if (PlayerPrefs.GetString("mushroomName" + i) == mushroomData.allMushroom[t].mushroomName)
                    {
                        mushroom.costByQuality = mushroomData.allMushroom[t].costByQuality;
                        mushroom.mushroomName = mushroomData.allMushroom[t].mushroomName;
                        mushroom.icon = mushroomData.allMushroom[t].icon;
                        mushroom.rarity = mushroomData.allMushroom[t].rarity;
                        break;
                    }
                }
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
            PlayerPrefs.SetString("mushroomName" + i, basket.mushroomsInBasket[i].mushroomName);
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

