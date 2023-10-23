using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public int[] cost;

    public float maxTime;
    public float currentTime = 0;
    int _buildID;
    public int buildID = -1;
    public GameObject zone;
    public GameObject buildingGO;
    public GameObject[] allFactory;
    public GameObject spawnPoint;

    public TMP_Text timerText;
    public TMP_Text costText;

    public GameObject CanvasMenu;
    public GameObject windowMenu;

    public GameObject NextZone;

    [HideInInspector]public BaseFactory factory;

    private float lastUpdateTime = 0f;
    private void Start()
    {
        if (currentTime == 0 && buildID < 0)
        {
            zone.SetActive(true);
            buildingGO.SetActive(false);
        }

        timerText.text = FormatTime(maxTime - (int)currentTime);

        
    }
    public void SpawningFactory()
    {
        if (buildID < 0)
        {
            return;
        }
        GameObject go = Instantiate(allFactory[buildID], spawnPoint.transform.position, spawnPoint.transform.rotation);
        factory = go.GetComponent<BaseFactory>();
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
        if (currentTime - lastUpdateTime >= 1f)
        {
            lastUpdateTime = currentTime;
            string currentFormattedTime = FormatTime(maxTime - (int)currentTime);

            timerText.text = currentFormattedTime;
        }
        if (currentTime >= maxTime)
        {
            SpawningFactory();
        }
    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    public void ShowHideCanvas()
    {
        CanvasMenu.SetActive(!CanvasMenu.activeSelf);
    }

    public void ShowHideWindow()
    {
        windowMenu.SetActive(!windowMenu.activeSelf);
        _buildID = -1;
        
        ResetCostText();
    }

    public void ChooseBuildingBTN(int BuildID)
    {
        _buildID = BuildID;
        ResetCostText();
    }
    public void BuildIDSetterBTN()
    {
        if (!PlayerData.instance.DecreaceMoney(cost[_buildID]))
        {
            return;
        }
        ResetCostText();
        buildID = _buildID;
        ShowHideWindow();
        ShowHideCanvas();
       
    }

    void ResetCostText()
    {
        if (_buildID < 0)
        {
            costText.text = "---";
            return;
        }
        costText.text = cost[_buildID] + "<sprite=3>";
    }
}
