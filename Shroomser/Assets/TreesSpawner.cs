using UnityEngine;
using UnityEditor;
public class TreesSpawner : MonoBehaviour
{
    public GameObject[] treePrefabs;
    public int numberOfTrees;
    public float xMin, xMax, zMin, zMax;

    public GameObject AllWood;
    public void SpawnTrees()
    {
        if (AllWood != null)
            DestroyImmediate(AllWood);

        AllWood = new GameObject();
        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 position = new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax));
            GameObject treePrefab = treePrefabs[Random.Range(0, treePrefabs.Length)];
            Instantiate(treePrefab, position, Quaternion.identity, AllWood.transform);
        }
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(TreesSpawner))]
public class SpawTree : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TreesSpawner test = (TreesSpawner)target;
        if (GUILayout.Button("Spawn trees"))
        {
            test.SpawnTrees();
        }

    }
}
#endif
