using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomRarity : MonoBehaviour
{

    public static MushroomRarity instance;

    private void Awake()
    {
        instance = this;
    }
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
    }

    public float GetValueFromEnum(Rarity myEnum)
    {
        switch (myEnum)
        {
            case Rarity.Common:
                return 0.5f;
            case Rarity.Uncommon:
                return 0.35f;
            case Rarity.Rare:
                return 0.15f;

            default:
                return 0;
        }
    }

    /*
            Fantastic,
            Legendary
     * 
            case Rarity.Fantastic:
                return 0.08f;
            case Rarity.Legendary:
                return 0.02f;
      */
}
