﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]  float WalkSpeed = 6f;
    public float MaxSpeed;

    [SerializeField] float gravity = -13.0f;

    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;

    float velocityY = 0.0f;

    CharacterController controller;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    public VariableJoystick Joystick;

    public Animator Animator;
    public SpeedValue SpeedValue;
    public RotatePlayer rotatePlayer;

    public static Movement instance;

    private void Awake()
    {
        instance = GetComponent<Movement>();
    }
    void Start()
    {
        WalkSpeed = MaxSpeed;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateMovement();

        if (SpeedValue.velocity.magnitude > 0.1f)
        {
            Animator.SetBool("Walk", true);
        }
        if (Joystick.Horizontal + Joystick.Vertical == 0)
        {
            Animator.SetBool("Walk", false);
        }
        Animator.SetFloat("Speed", SpeedValue.velocity.magnitude / MaxSpeed);
    }

    public void DecreaceSpeed(float valueInProcent)
    {
        WalkSpeed = WalkSpeed - ((MaxSpeed * valueInProcent) / 100);
        WalkSpeed = Mathf.Clamp(WalkSpeed, 0, MaxSpeed);
        rotatePlayer.CurrentSmoothRotate = rotatePlayer.CurrentSmoothRotate - ((rotatePlayer.MaxSmoothRot * valueInProcent) / 100);
    }
    public void IncreaceSpeed(int valueInProcent)
    {
        WalkSpeed = WalkSpeed + ((MaxSpeed * valueInProcent) / 100);
        WalkSpeed = Mathf.Clamp(WalkSpeed, 0, MaxSpeed);
        rotatePlayer.CurrentSmoothRotate = rotatePlayer.CurrentSmoothRotate + ((rotatePlayer.MaxSmoothRot * valueInProcent) / 100);
    }

    void UpdateMovement()
    {
        Vector2 targenDir = new Vector2(Joystick.Direction.x, Joystick.Direction.y);

        currentDir = Vector2.SmoothDamp(currentDir, targenDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }
        velocityY += gravity * Time.deltaTime;
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * WalkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }
}
