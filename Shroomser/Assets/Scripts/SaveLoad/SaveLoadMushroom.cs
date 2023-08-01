using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMushroom : MonoBehaviour
{
    public static SaveLoadMushroom instance;
    public List<GameObject> Mushroom;
    List<GameObject> _OldMushroom;
    public MushroomData mushroomData;
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

            PlayerPrefs.SetFloat("ScaleX" + i, Mushroom[i].transform.localScale.x);
            PlayerPrefs.SetFloat("ScaleY" + i, Mushroom[i].transform.localScale.y);
            PlayerPrefs.SetFloat("ScaleZ" + i, Mushroom[i].transform.localScale.z);
            PlayerPrefs.SetString("Name" + i, Mushroom[i].GetComponent<BaseMushroom>().GetOriginalMushroom().mushroomName);
        }
        PlayerPrefs.SetInt("MushroomNumber", Mushroom.Count);
    }

    public void LoadMushroom()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("MushroomNumber"); i++)
        {
            Vector3 pos = new Vector3(PlayerPrefs.GetFloat("PosX" + i), PlayerPrefs.GetFloat("PosY" + i), PlayerPrefs.GetFloat("PosZ" + i));
            Vector3 scale = new Vector3(PlayerPrefs.GetFloat("ScaleX" + i), PlayerPrefs.GetFloat("ScaleY" + i), PlayerPrefs.GetFloat("ScaleZ" + i));
            for (int t = 0; t < mushroomData.allMushroom.Length; t++)
            {
                if (PlayerPrefs.GetString("Name" + i) == mushroomData.allMushroom[t].mushroomName)
                {
                    GameObject mush = Instantiate(mushroomData.allMushroom[t].Prefab, pos, Quaternion.identity);
                    mush.transform.localScale = scale;
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
