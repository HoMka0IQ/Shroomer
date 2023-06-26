using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMushroom : MonoBehaviour
{

    [SerializeField] private ScriptableObjectMushroom mushroom;
    [HideInInspector] public  ScriptableObjectMushroom _mushroom;
    public MushroomRarity.Rarity rarity;


    private void Start()
    {
        _mushroom = ScriptableObject.CreateInstance<ScriptableObjectMushroom>();
        _mushroom = mushroom;
    }

}
