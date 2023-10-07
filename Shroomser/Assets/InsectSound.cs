using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSound : MonoBehaviour
{
    public AudioClip[] soundDeadInsect;

    public static InsectSound instance;

    public AudioSource audioSource;

    public void Awake()
    {
        instance = this;
    }

    public void PlaySound()
    {
        audioSource.clip = soundDeadInsect[Random.Range(0, soundDeadInsect.Length)];
        audioSource.Play();
    }
}
