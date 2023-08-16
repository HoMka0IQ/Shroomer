using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class findAllRotateTree : MonoBehaviour
{


    public void rotate()
    {
        List<Transform> allTree = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            allTree.Add(transform.GetChild(i));
        }
        for (int i = 0; i < allTree.Count; i++)
        {
            allTree[i].rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(findAllRotateTree))]
    public class findAllRotateTrees : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            findAllRotateTree test = (findAllRotateTree)target;
            if (GUILayout.Button("Rotate"))
            {
                test.rotate();
            }

        }
    }
#endif
}
