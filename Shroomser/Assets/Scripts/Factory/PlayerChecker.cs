using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerChecker : MonoBehaviour
{
    public UnityEvent playerEnter;
    public UnityEvent playerExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerExit.Invoke();
        }
    }
}
