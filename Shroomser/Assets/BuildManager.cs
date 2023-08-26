using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public int cost;

    public float maxTime;
    public float currentTime = 0;
    int _buildID;
    public int buildID = -1;
    public GameObject zone;
    public GameObject buildingGO;
    public GameObject[] allFactory;
    public GameObject spawnPoint;

    public TMP_Text timerText;


    public GameObject CanvasMenu;
    public GameObject windowMenu;

    public GameObject NextZone;
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
        if (NextZone != null)
        {
            NextZone.SetActive(true);
        }
        
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

    public void ShowHideCanvas()
    {
        CanvasMenu.SetActive(!CanvasMenu.activeSelf);
        _buildID = -1;
    }

    public void ShowHideWindow()
    {
        windowMenu.SetActive(!windowMenu.activeSelf);
    }

    public void ChooseBuildingBTN(int BuildID)
    {
        _buildID = BuildID;

    }
    public void BuildIDSetterBTN()
    {
        if (!PlayerData.instance.DecreaceMoney(cost))
        {
            return;
        }

        buildID = _buildID;
        ShowHideWindow();
        ShowHideCanvas();
    }
}
