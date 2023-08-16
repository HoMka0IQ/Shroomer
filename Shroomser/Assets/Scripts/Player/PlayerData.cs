using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    float money;
    public static PlayerData instance;

    public TMP_Text moneyText;
    private void Awake()
    {
        instance = this;
    }
    public void IncreaceMoney(int money)
    {
        this.money += money;
        resetMoneyText();
    }
    public bool DecreaceMoney(int money)
    {
        if (this.money - money < 0)
        {
            return false;
        }
        else
        {
            this.money -= money;
            resetMoneyText();
            return true;
        }
    }

    void resetMoneyText()
    {
        moneyText.text = money + "";
    }    
}
