using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    public GameObject[] windows;
    public static WindowsManager instance;
    private void Awake()
    {
        instance = GetComponent<WindowsManager>();
    }

    public void ClostAllWindows()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
    }
}
