using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineTime : MonoBehaviour
{
    TimeSpan ts;
    public string TimeOff;
    public int AllInSecond;

    public static OfflineTime instance;
    private void Awake()
    {
        instance = GetComponent<OfflineTime>();
    }
    void Start()
    {

        StartCoroutine(timer());
        if (PlayerPrefs.HasKey("LastSession"))
        {
            ts = DateTimeOffset.UtcNow - DateTimeOffset.Parse(PlayerPrefs.GetString("LastSession"));
            TimeOff = ts.Days + ":" + ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
            AllInSecond = ts.Seconds + (ts.Minutes * 60) + (ts.Hours * 60 * 60) + (ts.Days * 60 * 60 * 24);
        }
        
    }
    
    IEnumerator timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            saves();
        }
    }

    public void saves()
    {
        PlayerPrefs.SetString("LastSession", DateTimeOffset.UtcNow.ToString());
       
    }
    private void OnApplicationQuit()
    {
        saves();
    }
}
