using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChecker : MonoBehaviour
{
    public CarManager carManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            carManager.AddBox(other.GetComponent<BoxManager>().cost);
            Destroy(other.gameObject);
        }
    }
}
