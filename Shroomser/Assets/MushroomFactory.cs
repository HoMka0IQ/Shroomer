using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MushroomFactory : MonoBehaviour
{
    public TMP_Text number;
    public int MaxCount;
    public int CurrentCount;

    private void Start()
    {
        CurrentCount = MaxCount;
    }
}
