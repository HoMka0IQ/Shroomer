using UnityEngine;

public class MushroomSpawnerManager : MonoBehaviour
{
    public MushroomSpawner[] allSpawners;
    public SaveLoadMushroom saveLoadMushroom;
    [Range(0f,1f)]
    public float SpawnChance;
    void Start()
    {
        allSpawners = FindObjectsOfType<MushroomSpawner>();
    }

    void Update()
    {
        if (saveLoadMushroom.Mushroom.Count < allSpawners.Length * SpawnChance)
        {
            allSpawners[Random.Range(0, allSpawners.Length)].Spawn();
        }
    }
}
