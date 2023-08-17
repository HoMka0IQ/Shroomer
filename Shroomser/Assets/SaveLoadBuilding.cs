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
        List<BuildManager> CleareMushroom = new List<BuildManager>();
        for (int i = 0; i < allbuildManager.Count; i++)
        {
            if (allbuildManager[i] != null)
            {
                CleareMushroom.Add(allbuildManager[i]);
            }
        }
        allbuildManager = CleareMushroom;
        for (int i = 0; i < allbuildManager.Count; i++)
        {
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
            allbuildManager[i].buildID = PlayerPrefs.GetInt("buildID" + i);
            allbuildManager[i].currentTime = PlayerPrefs.GetFloat("buildTimer" + i);
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
