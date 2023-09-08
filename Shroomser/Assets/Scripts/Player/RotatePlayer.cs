using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public VariableJoystick variableJoystick;

    public float MaxSmoothRot;
    public float CurrentSmoothRotate;

    public bool HorizontalR;
    public bool VerticalR;
    public void Start()
    {
        CurrentSmoothRotate = MaxSmoothRot;
    }
    void Update()
    {
        ControllPlayer();

    }
    void ControllPlayer()
    {
        Vector3 movement = new Vector3(variableJoystick.Direction.x, 0.0f, variableJoystick.Direction.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), CurrentSmoothRotate * Time.deltaTime) ;
        }
    }




}