using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectHiderFromCam : MonoBehaviour
{

    MeshRenderer MR;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("HideFromCam"))
        {
            other.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("HideFromCam"))
        {
            other.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
        }
    }
}
