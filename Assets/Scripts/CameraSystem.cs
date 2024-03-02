using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    private bool isIngame = true;

    void Update()
    {
        if (isIngame) EdgeScrolling();
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            menuScreen.SetActive(true);
            isIngame = false; //åpner menu. Bør settes til å lukke igjen med esc også
        }
    }

    private void EdgeScrolling()
    {
        {
            Vector3 inputDir = Vector3.zero;
            int edgeScrollSize = 20;

            if (Input.mousePosition.x < edgeScrollSize) inputDir.x = -1f;
            if (Input.mousePosition.y < edgeScrollSize) inputDir.z = -1f;
            if (Input.mousePosition.x > Screen.width - edgeScrollSize) inputDir.x = 1f;
            if (Input.mousePosition.y > Screen.height - edgeScrollSize) inputDir.z = 1f;

            Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
            transform.position += moveDir * 50f * Time.deltaTime;
        }
    }

    public void Continue()
    {
        isIngame = true;
    }
}