using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public float maxTime;
    public float currentTime = 0;
    int _buildID;
    public int buildID = -1;
    public GameObject zone;
    public GameObject buildingGO;
    public GameObject[] allFactory;
    public GameObject spawnPoint;

    public TMP_Text timerText;

    public GameObject btnMenu;
    private void Start()
    {
        if (currentTime == 0 && buildID < 0)
        {
            zone.SetActive(true);
            buildingGO.SetActive(false);
        }
    }
    public void SetActiveBuild()
    {
        if (buildID < 0)
        {
            return;
        }
        Instantiate(allFactory[buildID], spawnPoint.transform.position, spawnPoint.transform.rotation);
        zone.SetActive(false);
        buildingGO.SetActive(false);
    }

    private void Update()
    {
        if (buildID <= -1 || currentTime >= maxTime)
        {
            return;
        }
        buildingGO.SetActive(true);
        zone.SetActive(false);
        currentTime += Time.deltaTime;
        timerText.text = maxTime - (int)currentTime + "";
        if (currentTime >= maxTime)
        {
            SetActiveBuild();
        }
    }

    public void ShowBtn(GameObject menu)
    {
        menu.SetActive(true);
        _buildID = -1;
    }

    public void HideBtn()
    {
        btnMenu.SetActive(false);
    }

    public void ChooseBuildingBTN(int BuildID)
    {
        _buildID = BuildID;

    }
    public void BuildIDSetterBTN()
    {
        buildID = _buildID;
        btnMenu.SetActive(false);
    }
}
