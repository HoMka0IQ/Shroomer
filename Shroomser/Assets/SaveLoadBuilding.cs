using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadBuilding : MonoBehaviour
{

    public List<BuildManager> allbuildManager;


    private void Awake()
    {
        loadSistem();
        StartCoroutine(SaveData());
    }

    public void SaveSistem()
    {


        for (int i = 0; i < allbuildManager.Count; i++)
        {
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
                allbuildManager[i].SetActiveBuild();

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
