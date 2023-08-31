using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerManager : MonoBehaviour
{
    public AudioSource stepAudioSource;

    [Header("Wood step sound")]
    public AudioClip[] allSoundWoodenStep;

    [Header("Ground step sound")]
    public AudioClip[] allSoundGroundStep;


    public void PlayStepSound()
    {
        RaycastHit hit;
        Vector3 rayStartPosition = transform.root.position;

        if (Physics.Raycast(rayStartPosition, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                stepAudioSource.clip = allSoundGroundStep[Random.Range(0, allSoundWoodenStep.Length)];
                stepAudioSource.volume = 0.3f;
            }
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("WoodenFloor"))
            {
                stepAudioSource.clip = allSoundWoodenStep[Random.Range(0, allSoundWoodenStep.Length)];
                stepAudioSource.volume = 0.8f;
            }
        }
        stepAudioSource.Play();
    }

}
