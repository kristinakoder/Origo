using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayableObject : MonoBehaviour
{
    [SerializeField] private GameObject selectVectorsScreen; //skal ikke ha denne
    [SerializeField] private GameObject glow; 
    [SerializeField] private VectorInput vectorInputs; //skal ikke ha denne
    [SerializeField] private Objectives objectives; //skal ikke ha disse
    public MoveVectors moveVectors; 
    public UnityEvent playerClicked;

    private bool CubeSelected = false;
    private bool isMoving = false;
    bool wDown = false, aDown = false, sDown = false, dDown = false;
    
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
        playerClicked?.Invoke();
        if (objectives.objectives[0].IsActive)
        {
            objectives.objectives[0].Complete();
            objectives.objectives[1].IsActive = true;
            objectives.ShowObjective();
        } 
    }

    void MoveCube()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            moveDir -= moveAD;
            aDown = true;
            if (objectives.objectives[2].IsActive) 
            {
                objectives.objectives[2].Complete();
                objectives.objectives[3].IsActive = true;
                objectives.ShowObjective();
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
            if (objectives.objectives[2].IsActive) 
            {
                objectives.objectives[2].Complete();
                objectives.objectives[3].IsActive = true;
                objectives.ShowObjective();
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