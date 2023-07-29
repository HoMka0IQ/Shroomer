using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimController : MonoBehaviour
{
    Animator CarAnimator;
    string currentAnim;

    void Start()
    {
        CarAnimator = GetComponent<Animator>();
    }

    public void SetAnim(string AnimName)
    {
        if (currentAnim == AnimName)
        {
            return;
        }
        CarAnimator.Play(AnimName);
        currentAnim = AnimName;
    }
}
