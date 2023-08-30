using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMushroom : MonoBehaviour
{
    public static SaveLoadMushroom instance;
    public List<GameObject> Mushroom;
    List<GameObject> _OldMushroom;
    public ItemData mushroomData;
    private void Awake()
    {
        instance = this;
        LoadMushroom();
        StartCoroutine(SaveData());
    }

    public void AddMushroom(GameObject mushroom)
    {
        Mushroom.Add(mushroom);
        SaveMushroom();
    }

    public void SaveMushroom()
    {
        List<GameObject> CleareMushroom = new List<GameObject>();
        for (int i = 0; i < Mushroom.Count; i++)
        {
            if (Mushroom[i] != null)
            {
                CleareMushroom.Add(Mushroom[i]);
            }
        }
        Mushroom = CleareMushroom;
        for (int i = 0; i < Mushroom.Count; i++)
        {
            PlayerPrefs.SetFloat("PosX" + i, Mushroom[i].transform.position.x);
            PlayerPrefs.SetFloat("PosY" + i, Mushroom[i].transform.position.y);
            PlayerPrefs.SetFloat("PosZ" + i, Mushroom[i].transform.position.z);


            PlayerPrefs.SetString("Name" + i, Mushroom[i].GetComponent<BaseMushroom>().GetItemMushroom().itemName);
        }
        PlayerPrefs.SetInt("MushroomNumber", Mushroom.Count);
    }

    public void LoadMushroom()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("MushroomNumber"); i++)
        {
            Vector3 pos = new Vector3(PlayerPrefs.GetFloat("PosX" + i), PlayerPrefs.GetFloat("PosY" + i), PlayerPrefs.GetFloat("PosZ" + i));

            for (int t = 0; t < mushroomData.allItem.Length; t++)
            {
                if (PlayerPrefs.GetString("Name" + i) == mushroomData.allItem[t].itemName)
                {
                    GameObject mush = Instantiate(mushroomData.allItem[t].Prefab, pos, Quaternion.identity);
                    Mushroom.Add(mush);
                }
            }
            
        }
    }
    IEnumerator SaveData()
    {
        while (true)
        {
            SaveMushroom();
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnApplicationQuit()
    {
        SaveMushroom();
    }
}
