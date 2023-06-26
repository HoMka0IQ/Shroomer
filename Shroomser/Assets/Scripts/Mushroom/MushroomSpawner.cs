using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MushroomSpawner : MonoBehaviour
{
    public void Spawn()
    {
        int randNumber = Random.Range(0, 100);
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
