using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5;
    
    public Camera cam;
    private float xRotation = 0;

    public float xSensitivity = 30;
    public float ySensitivity = 30;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessMove(Vector3 input) 
    {
        Vector3 moveDirection = transform.forward * input.z + transform.right * input.x;
        moveDirection.y = input.y > 0 ? 1 : (input.y < 0 ? -1 : 0);
        controller.Move(speed * Time.deltaTime * moveDirection.normalized);
    }

    public void ProcessLook(Vector2 input)
    {
        xRotation -= input.y * Time.deltaTime * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // Rotate the camera vertically
        transform.Rotate(Vector3.up * (input.x * Time.deltaTime) * xSensitivity); // Rotate the player (main camera) horizontally
    }
}
