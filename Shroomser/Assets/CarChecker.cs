using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            other.gameObject.SetActive(false);
            Debug.Log("ww");
        }
    }
}
