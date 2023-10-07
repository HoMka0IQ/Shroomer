using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Insect : MonoBehaviour
{

    public int IncreaseQuality;


    private void OnMouseUp()
    {
        Item3DViewer.instance.MushroomData.IncreaseQuality(IncreaseQuality);
        InsectSound.instance.PlaySound();
        Destroy(gameObject);
    }
}
