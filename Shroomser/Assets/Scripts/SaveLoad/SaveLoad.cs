using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    public Basket basket;
    public MushroomData mushroomData;

    public CarManager carManager;

    private void Awake()
    {
        loadSistem();
        StartCoroutine(SaveData());
    }

    public void loadSistem()
    {


        //Basket
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
        //Car
        if (PlayerPrefs.HasKey("CarTimer") && PlayerPrefs.GetInt("CarBoxCount") > 0)
        {
            carManager.currentCD_Time = PlayerPrefs.GetFloat("CarTimer");
            carManager.currentCD_Time -= OfflineTime.instance.AllInSecond;
            Debug.Log(carManager.currentCD_Time);
            Debug.Log(OfflineTime.instance.AllInSecond);
            carManager.currentCD_Time = Mathf.Clamp(carManager.currentCD_Time, 0, carManager.maxCD_Timer);
            if (carManager.currentCD_Time < carManager.maxCD_Timer)
            {
                carManager.MainCarGO.SetActive(false);
            }
            else
            {
                carManager.MainCarGO.SetActive(true);
                carManager.carAnimController.SetAnim("Idle_Car");
            }
        }
        else
        {
            carManager.currentCD_Time = carManager.maxCD_Timer;
        }

        if (PlayerPrefs.HasKey("CarBoxCount"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("CarBoxCount"); i++)
            {
                carManager.currentBox.Add(PlayerPrefs.GetInt("CarBoxCoxt" + i));
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
        //Car
        PlayerPrefs.SetFloat("CarTimer", carManager.currentCD_Time);
        PlayerPrefs.SetInt("CarBoxCount", carManager.currentBox.Count);
        for (int i = 0; i < carManager.currentBox.Count; i++)
        {
            PlayerPrefs.SetInt("CarBoxCoxt" + i, carManager.currentBox[i]);
        }
        
    }


    IEnumerator SaveData()
    {
        while (true)
        {
            SaveSistem();
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnApplicationQuit()
    {
        SaveSistem();
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

