using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public AudioSource insectAudioSource;
    float Timer;
    void Start()
    {
        ResetTimer();
    }


    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                insectAudioSource.Play();
                ResetTimer();
            }

        }
    }

    public void ResetTimer()
    {
        Timer = Random.Range(90, 300);
    }
}
