using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFactoryManager : MonoBehaviour
{
    public GameObject Menu;
    private void Start()
    {
        HideMenu();
    }
    public void ShowMenu()
    {
        Menu.SetActive(true);
    }
    public void HideMenu()
    {
        Menu.SetActive(false);
    }
}
