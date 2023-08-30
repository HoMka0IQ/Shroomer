using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadBuilding : MonoBehaviour
{

    public List<BuildManager> allbuildManager;

    public ItemData itemData;


    private void Awake()
    {
        loadSistem();
        StartCoroutine(SaveData());
    }

    public void SaveSistem()
    {
        for (int i = 0; i < allbuildManager.Count; i++)
        {
            //Builds
            int activeBuilding;
            if (allbuildManager[i].gameObject.activeSelf == true)
            {
                activeBuilding = 1;
            }
            else
            {
                activeBuilding = 0;
            }
            PlayerPrefs.SetInt("ActiveSelfBuild" + i, activeBuilding);

            PlayerPrefs.SetInt("buildID" + i, allbuildManager[i].buildID);
            PlayerPrefs.SetFloat("buildTimer" + i, allbuildManager[i].currentTime);

            //Factories
            if (allbuildManager[i].factory != null)
            {
                PlayerPrefs.SetInt("MaxCountInFactory" + i, allbuildManager[i].factory.MaxCount);
                PlayerPrefs.SetFloat("TimerInFactory" + i, allbuildManager[i].factory._currentTimer);

                if (allbuildManager[i].factory.isWorking)
                {
                    PlayerPrefs.SetInt("IsWorkingFactory" + i, 1);
                }
                else
                {
                    PlayerPrefs.SetInt("IsWorkingFactory" + i, 0);
                }

                for (int t = 0; t < allbuildManager[i].factory.ItemInFactory.Count; t++)
                {
                    PlayerPrefs.SetString("ItemNameInFactory" + i + "/" + t, allbuildManager[i].factory.ItemInFactory[t].itemName);
                    PlayerPrefs.SetFloat("ItemQualityInFactory" + i + "/" + t, allbuildManager[i].factory.ItemInFactory[t].currentQuality);
                }
                PlayerPrefs.SetInt("CountItemInFactory" + i, allbuildManager[i].factory.ItemInFactory.Count);
            }


        }
        PlayerPrefs.SetInt("BuildingManagerCount", allbuildManager.Count);
    }

    public void loadSistem()
    {
        if (PlayerPrefs.HasKey("BuildingManagerCount") == false)
        {
            return;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("BuildingManagerCount"); i++)
        {
            if (PlayerPrefs.GetInt("ActiveSelfBuild" + i) != 0)
            {
                allbuildManager[i].gameObject.SetActive(true);
            }


            allbuildManager[i].buildID = PlayerPrefs.GetInt("buildID" + i);
            allbuildManager[i].currentTime = PlayerPrefs.GetFloat("buildTimer" + i);
            if (allbuildManager[i].buildID > -1)
            {
                allbuildManager[i].currentTime += OfflineTime.instance.AllInSecond;
            }
 
            if (allbuildManager[i].currentTime >= allbuildManager[i].maxTime)
            {
                allbuildManager[i].SpawningFactory();

            }
            //
            if (allbuildManager[i].factory != null)
            {
                allbuildManager[i].factory.MaxCount = PlayerPrefs.GetInt("MaxCountInFactory" + i);
                allbuildManager[i].factory._currentTimer = PlayerPrefs.GetFloat("TimerInFactory" + i);

                
                if (PlayerPrefs.GetInt("IsWorkingFactory" + i) == 1)
                {
                    allbuildManager[i].factory.isWorking = true;
                }

                if (allbuildManager[i].factory.isWorking == true)
                {
                    allbuildManager[i].factory._currentTimer += OfflineTime.instance.AllInSecond;
                }

                //fill factory with items
                for (int t = 0; t < PlayerPrefs.GetInt("CountItemInFactory" + i); t++)
                {
                    for (int y = 0; y < itemData.allItem.Length; y++)
                    {
                        if (PlayerPrefs.GetString("ItemNameInFactory" + i + "/" + t) == itemData.allItem[y].itemName)
                        {
                            allbuildManager[i].factory.ItemInFactory.Add(Instantiate(itemData.allItem[y]));
                            allbuildManager[i].factory.ItemInFactory[t].currentQuality = PlayerPrefs.GetFloat("ItemQualityInFactory" + i + "/" + t);
                        }
                    }
                }
            }
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
}
