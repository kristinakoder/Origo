using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] public GameObject lineAD;
    [SerializeField] public GameObject lineWS;
    [SerializeField] private GameObject selectVectorsScreen;
    [SerializeField] private GameObject glow;
    [SerializeField] private VectorInput vectorInputs;
    public Objectives tasks;

    private bool CubeSelected = false;
    private bool isMoving = false;
    bool wDown = false, aDown = false, sDown = false, dDown = false, aPressed = false, dPressed = false;
    
    public Vector3 moveAD = new(0,0,0);
    public Vector3 moveWS = new(0,0,0);
    Vector3 moveDir = Vector3.zero;

    void Start()
    {
    }

    void Update()
    {
        if (CubeSelected)
        {
            glow.SetActive(true); 
            MoveCube();

        } else 
        {
            glow.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        CubeSelected = !CubeSelected;
        if (tasks.tasks[0].isActive)
        {
            tasks.tasks[0].isActive = false;
            tasks.tasks[1].isActive = true;
            tasks.UpdateTask();
        }
    }

    void MoveCube()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            moveDir -= moveAD;
            aDown = true;
            if (tasks.tasks[2].isActive)
            {
                tasks.tasks[2].isActive = false;
                tasks.tasks[3].isActive = true;
                tasks.UpdateTask();
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveDir += moveAD;
            aDown = false;
        } 
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            moveDir += moveAD;
            dDown = true;
            if (tasks.tasks[2].isActive)
            {
                tasks.tasks[2].isActive = false;
                tasks.tasks[3].isActive = true;
                tasks.UpdateTask();
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveDir -= moveAD;
            dDown = false;
        } 
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDir += moveWS;
            wDown = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveDir -= moveWS;
            wDown = false;
        } 
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDir -= moveWS;
            sDown = true;
        } 
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveDir += moveWS;
            sDown = false;
        } 

        if (wDown || aDown || sDown || dDown) isMoving = true;
        if (!wDown && !aDown && !sDown && !dDown) isMoving = false;

        if (isMoving) 
        {
            transform.position += moveDir * 1f * Time.deltaTime;
            vectorInputs.UpdateVectorAD();
            vectorInputs.UpdateVectorWS();
        }
    }
}