using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarManager : MonoBehaviour
{
    public List<int> currentBox = new List<int>();
    public int maxBox;
    public TMP_Text CountText;
    public GameObject BoxLoading;

    public GameObject MainCarGO;

    public float maxCD_Timer;
    public float currentCD_Time;

    [HideInInspector]public CarAnimController carAnimController;

    private void Start()
    {

        carAnimController = GetComponent<CarAnimController>();
        ReloadText();
    }

    public void ReloadText()
    {
        CountText.text = "(" + currentBox.Count + "/" + maxBox + ") <sprite=4>";
    }

    private void Update()
    {
        if (currentBox.Count < maxBox)
        {
            return;
        }
        currentCD_Time -= Time.deltaTime;
        if (currentCD_Time <= 0)
        {
            int allMoney = 0;
            for (int i = 0; i < currentBox.Count; i++)
            {
                allMoney += currentBox[i];
            }
            PlayerData.instance.IncreaceMoney(allMoney);

            currentBox.Clear();
            currentCD_Time = maxCD_Timer;
            ReloadText();
            MainCarGO.SetActive(true);
            carAnimController.SetAnim("Coming_Car");
            ChangeCarOrder();
            return;
        }
        OffBoxLoading();
        carAnimController.SetAnim("Ride_Car");
    }
    public void ChangeCarOrder()
    {
        maxBox = Random.Range(3, 5);
    }
    public void OffBoxLoading()
    {
        BoxLoading.SetActive(false);
    }
    public void OnBoxLoading()
    {
        BoxLoading.SetActive(true);
    }
    public bool AddBox(int boxCost)
    {
        if (currentBox.Count >= maxBox)
        {
            return false;
        }
        currentBox.Add(boxCost);
        ReloadText();
        return true;
    }
}
