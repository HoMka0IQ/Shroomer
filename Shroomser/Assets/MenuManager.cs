using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainPage;
    public GameObject SoundSettingsPage;

    public GameObject background;
    void OpenPage(GameObject page)
    {
        MainPage.SetActive(false);
        SoundSettingsPage.SetActive(false);
        page.SetActive(true);
        background.SetActive(true);
    }
    void ClosePages()
    {
        MainPage.SetActive(false);
        SoundSettingsPage.SetActive(false);
        background.SetActive(false);
    }
    public void OpenMainPage()
    {
        OpenPage(MainPage);
    }


    public void ResumeButton()
    {
        ClosePages();
    }
    
    public void SoundSettings()
    {
        OpenPage(SoundSettingsPage);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
