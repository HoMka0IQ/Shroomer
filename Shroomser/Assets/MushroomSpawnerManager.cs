using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawnerManager : MonoBehaviour
{
    public MushroomSpawner[] allSpawners;
    void Start()
    {
        allSpawners = FindObjectsOfType<MushroomSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
