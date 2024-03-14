using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject crosshair;
    private bool isIngame = true;
    private bool rightMouseDown = false;
    private bool edgeScrollingOn = false;
    private bool rotate = false;
    Vector2 lastMousePosition;
    Vector3 inputDir = Vector3.zero;
    float rotateX = 0, rotateY = 0;

    void Update()
    {
        if (isIngame)
        {
            if (edgeScrollingOn) EdgeScrolling();
            if (Input.GetKeyDown(KeyCode.LeftControl)) rotate = true;
            if (Input.GetKeyUp(KeyCode.LeftControl)) rotate = false;
            if (Input.GetMouseButtonDown(1))
            {
                edgeScrollingOn = false;
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
            MoveCamera();

        } 
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            isIngame = !isIngame;
            menuScreen.SetActive(!isIngame);
            gameUI.SetActive(isIngame);
        }
    }

    private void MoveCamera()
    {
        if (rightMouseDown)
        {        
            if (rotate) RotateCamera();
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
        rotateY += (Input.mousePosition.x - lastMousePosition.x) / 500;; //rotateY horizontal
        rotateX += (lastMousePosition.y - Input.mousePosition.y) / 500; //rotateX vertical
        rotateX = Mathf.Clamp(rotateX, -45, 45);
        //TODO: legge inn litt dødrom sånn at man ikke roterer bittelitt opp når man roterer til siden

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0f);
    }

    private void DefaultCameraView()
    {
        //men sånn fin flyvning, ikke sånn brått som det er nå
        //trenger å vite x, y og z... 
        //dersom de er negative, legge på litt float til 0, motsatt om positive..
        rotateX = rotateY = 0;
        transform.position = Vector3.zero;

        //trenger å vite x og y. 
        transform.rotation = Quaternion.Euler(rotateX,rotateY,0);
        
    }

    private void EdgeScrolling()
    {       
        inputDir = Vector3.zero;
        int edgeScrollSize = 20;

        if (Input.mousePosition.x < edgeScrollSize) inputDir.x = -1f;
        if (Input.mousePosition.y < edgeScrollSize) inputDir.z = -1f;
        if (Input.mousePosition.x > Screen.width - edgeScrollSize) inputDir.x = 1f;
        if (Input.mousePosition.y > Screen.height - edgeScrollSize) inputDir.z = 1f;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        transform.position += moveDir * 50f * Time.deltaTime;
    }

    public void Continue()
    {
        isIngame = true;
        gameUI.SetActive(isIngame);
    }
}