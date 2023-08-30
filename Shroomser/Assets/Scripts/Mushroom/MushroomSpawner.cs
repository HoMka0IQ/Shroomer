using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MushroomSpawner : MonoBehaviour
{

    GameObject Mushroom;
    public ItemData mushroomData;

    
    public void Spawn()
    {
        Collider[] mushrooms = Physics.OverlapSphere(transform.position, 5, LayerMask.GetMask("Items"));
        if (mushrooms.Length > 0)
        {
            return;
        }
        Vector2 randomCircle = Random.insideUnitCircle.normalized * Random.Range(3, 5);
        Vector3 spawnPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + transform.position;

        RaycastHit hit;
        Vector3 rayStartPosition = spawnPosition;

        if (Physics.Raycast(rayStartPosition, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {

                //Randomize
                float randomValue = Random.value;
                
                float totalWeight = 0;

                foreach (ScriptableObjectItem som in mushroomData.allItem)
                {
                    
                    totalWeight += MushroomRarity.instance.GetValueFromEnum(som.rarity);
                    if (randomValue <= totalWeight)
                    {
                        Mushroom = som.Prefab;
                        break;
                    }
                }
                //
                Vector3 rayEndPosition = hit.point;

                rayEndPosition.y += Mushroom.transform.localScale.y / 2;
                Debug.Log(Mushroom == null);
                Debug.Log(rayEndPosition == null);
                GameObject newObject = Instantiate(Mushroom, rayEndPosition, Quaternion.identity);
                SaveLoadMushroom.instance.AddMushroom(newObject);
            }
        }
    }


}

