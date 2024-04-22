using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayableObjectScript : MonoBehaviour
{
    public MoveVectors moveVectors;
    public Vector3Variable playablePosition;
    public GameEvent onPlayableMove;
    public UnityEvent sphereCollision;
    public BoolVariable isAddingVectors;
    Vector3 moveDir;
    bool isMoving = true;

    Vector3 MoveV {
        get { return moveVectors.V.Vec3; }
        set { moveVectors.V.Vec3 = value; }
    }
    Vector3 MoveW {
        get { return moveVectors.W.Vec3; }
        set { moveVectors.W.Vec3 = value; }
    }
    Vector3 MoveU {
        get { return moveVectors.U.Vec3; }
        set { moveVectors.U.Vec3 = value; }
    }

    void Start()
    {
        moveVectors.ResetVectors();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) 
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            isMoving = true;
            //onPlayableMove?.Raise();
        }    
            
        if (isMoving && !isAddingVectors.b)
            MovePlayable();

        if (Input.GetKey(KeyCode.O)) ResetPosition();
    }

    void MovePlayable()
    {
        moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) moveDir = -1 * MoveV;
        if (Input.GetKey(KeyCode.D)) moveDir = MoveV;     
        if (Input.GetKey(KeyCode.W)) moveDir = MoveW;
        if (Input.GetKey(KeyCode.S)) moveDir = -1 * MoveW;
        if (Input.GetKey(KeyCode.Space)) moveDir = 1 * MoveU;
        if (Input.GetKey(KeyCode.LeftShift)) moveDir = -1* MoveU;
        
        transform.position += moveDir * 1f * Time.deltaTime;
        playablePosition.Vec3 = transform.position;
    }

    public void SnapPosition(Vector3Variable v)
    {
        transform.position = playablePosition.Vec3 = v.Vec3;
        isMoving = false;
    }

    public void StartVectorW(int x, int y, int z)
    {
        MoveW = new Vector3(x, y, z);
    }

    public void SetLockedVectors()
    {
        MoveV = new Vector3(3,0,1);
        MoveW = new Vector3(3,0,2);
    }

    public void Get3DmoveVectors()
    {
        MoveV = new Vector3(-5,0,0);
        MoveW = new Vector3(0,0,-5);
        MoveU = new Vector3(0,5,0);
    }

    public void SetPosition3D()
    {
        transform.position = new Vector3(5,5,5);
    }

    public void ResetPosition()
    {
        transform.position = playablePosition.Vec3 = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point")) 
        { sphereCollision?.Invoke(); }
    }
}