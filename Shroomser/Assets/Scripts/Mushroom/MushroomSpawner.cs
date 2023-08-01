using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MushroomSpawner : MonoBehaviour
{

    public GameObject Mushroom;

    
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
                Vector3 rayEndPosition = hit.point;

                rayEndPosition.y += Mushroom.transform.localScale.y / 2;
                GameObject newObject = Instantiate(Mushroom, rayEndPosition, Quaternion.identity);
                float randomSize = Random.Range(0.75f, 1.5f);
                newObject.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
                SaveLoadMushroom.instance.AddMushroom(newObject);
            }
        }
    }


}
#if UNITY_EDITOR
[CustomEditor(typeof(MushroomSpawner))]
public class SpawnMushroom : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MushroomSpawner testw = (MushroomSpawner)target;
        if (GUILayout.Button("Spawn"))
        {
            testw.Spawn();
        }

    }
}
#endif
