using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject crosshair;
    GameObject virtualCamera;
    private bool rightMouseDown = false;
    Vector2 lastMousePosition;
    Vector3 inputDir = Vector3.zero;
    public BoolVariable is3D;

    float rotateX = 0, rotateY = 0;

    void Start()
    {
        
    }

    void Update()
    {
        MoveCamera();

        if (Input.GetMouseButtonDown(1))
        {
            rightMouseDown = true;
            lastMousePosition = Input.mousePosition;
            crosshair.transform.position = lastMousePosition;
            crosshair.SetActive(true);
        } 
        if (Input.GetMouseButtonUp(1)) 
        {
            rightMouseDown = false;
            crosshair.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftControl)) RotateCameraWithArrows();
        else MoveCameraWithArrows();
    }

    private void MoveCamera()
    {
        if (rightMouseDown)
        {        
            if (Input.GetKey(KeyCode.LeftControl)) RotateCamera();
            else DragCamera();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            DefaultCameraView();
        }
    }

    private void DragCamera()
    {
        //0.0 er bottom-left. Opp er y++, høyre x++
        inputDir.x = Input.mousePosition.x - lastMousePosition.x; 
        inputDir.z = Input.mousePosition.y - lastMousePosition.y;
        
        inputDir /= 10f;
        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        transform.position += moveDir * Time.deltaTime;
    }

    private void RotateCamera()
    {
        rotateY += (Input.mousePosition.x - lastMousePosition.x) / 500; //rotateY horizontal
        rotateX += (lastMousePosition.y - Input.mousePosition.y) / 500; //rotateX vertical
        rotateX = Mathf.Clamp(rotateX, -90, 45);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0f);
    }

    public void DefaultCameraView()
    {
        rotateX = 0;

        if (!is3D.b) 
        {
            transform.position = Vector3.zero;
            rotateY = 0;
        }
        else
        {
            rotateY = -35;
            transform.position = new Vector3(0,3,0);
        }
        RotateCamera();
    }

    private void MoveCameraWithArrows()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += 10 * Time.deltaTime * transform.forward;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position -= 10 * Time.deltaTime * transform.forward;
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position -= 10 * Time.deltaTime * transform.right;
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += 10 * Time.deltaTime * transform.right;
    }

    private void RotateCameraWithArrows()
    {
        if (Input.GetKey(KeyCode.UpArrow)) rotateX += 0.5f;
        if (Input.GetKey(KeyCode.DownArrow)) rotateX -= 0.5f;
        if (Input.GetKey(KeyCode.LeftArrow)) rotateY += 0.5f;
        if (Input.GetKey(KeyCode.RightArrow)) rotateY -= 0.5f;
        rotateX = Mathf.Clamp(rotateX, -90, 45);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0f);
    }

    private void Zoom()
    {
        
    }
}