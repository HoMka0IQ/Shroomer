using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    [Header("mushroom spawner")]
    public MushroomSpawner[] allSpawners;
    public SaveLoadMushroom saveLoadMushroom;
    [Range(0f,1f)]
    public float SpawnChance;

    [Header("Sound spawner")]
    public List<AudioSource> allWoodAS;
    public float Timer = 10;
    public AudioClip[] allSound;
    void Start()
    {
        allSpawners = FindObjectsOfType<MushroomSpawner>();
        for (int i = 0; i < allSpawners.Length; i++)
        {
            allWoodAS.Add(allSpawners[i].GetComponent<AudioSource>());
        }
    }

    void Update()
    {
        mushroomSpawner();
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                int randomWood = Random.Range(0, allWoodAS.Count - 1);
                int randomSound = Random.Range(0, allSound.Length);
                allWoodAS[randomWood].clip = allSound[randomSound];
                allWoodAS[randomWood].Play();
                Timer = Random.Range(10, 300);
            }
        }
    }

    public void mushroomSpawner()
    {
        if (saveLoadMushroom.Mushroom.Count < allSpawners.Length * SpawnChance)
        {
            allSpawners[Random.Range(0, allSpawners.Length)].Spawn();
        }
    }
}
