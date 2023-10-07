using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public float timer;
    public int FPSCount;
    public TMP_Text fpsText;

    private void Update()
    {
        FPSCount++;
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            fpsText.text = FPSCount + "";
            FPSCount = 0;
            timer = 0;
        }
    }
}
