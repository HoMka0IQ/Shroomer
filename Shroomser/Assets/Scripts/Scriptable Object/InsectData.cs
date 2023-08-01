using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObkectMushroom", menuName = "Custom/InsectData")]
public class InsectData : ScriptableObject
{
    public GameObject[] InsectPrefab;
    public int[] IncreaseQuality;

}
