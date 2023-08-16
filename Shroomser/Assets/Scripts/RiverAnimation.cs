using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverAnimation : MonoBehaviour
{
    Material material;
    float offsetY;
    public float speed;
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset = new Vector2(0, offsetY);
        offsetY += Time.deltaTime * speed;
    }
}
