using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class PlayableObjectScript : MonoBehaviour
{
    [SerializeField] private MoveVectors moveVectors;
    [SerializeField] private Vector3Variable playablePosition;
    [SerializeField] private BoolVariable canMove, isMoving;
    [SerializeField] private GameEvent onMoveVectorsUsed;
    [SerializeField] private IntVariable addedScoreForCollision;
    [SerializeField] private UnityEvent sphereCollision;

    char lastVectorUsed = '?';

    Vector3 moveDir; 

    Vector3 MoveV => moveVectors.V.GetNormalized();
    Vector3 MoveW => moveVectors.W.GetNormalized();
    Vector3 MoveU => moveVectors.U.GetNormalized();

    void Start()
    {
        canMove.b = false;
        addedScoreForCollision.i = 5;
        //moveVectors.ResetVectors();
        playablePosition.Vec3 = transform.position;
    }

    void Update()
    {   
        if (canMove.b) 
        {
            if (lastVectorUsed != '?') DeductPointForVectorUse();
            MovePlayable();
        }

        if (Input.GetKey(KeyCode.O)) ResetPosition();

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) canMove.b = true;
    }

    private void DeductPointForVectorUse()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && lastVectorUsed != 'V') 
            addedScoreForCollision.DecrementToMinOne();

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && lastVectorUsed != 'W') 
            addedScoreForCollision.DecrementToMinOne();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift)) && lastVectorUsed != 'U') 
            addedScoreForCollision.DecrementToMinOne();
    }

    public void MoveTo3DSpace()
    {
        transform.position = playablePosition.Vec3 = new Vector3(5, 5, -5);
    }

    void MovePlayable()
    {
        moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) 
        {
            moveDir = -1 * MoveV;
            lastVectorUsed = 'V';
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            moveDir = MoveV;
            lastVectorUsed = 'V';
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            moveDir = MoveW;
            lastVectorUsed = 'W';
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            moveDir = -1 * MoveW;
            lastVectorUsed = 'W';
        }
        if (Input.GetKey(KeyCode.Space)) 
        {
            moveDir = 1 * MoveU;
            lastVectorUsed = 'U';
        }
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            moveDir = -1* MoveU;
            lastVectorUsed = 'U';
        }

        isMoving.b = moveDir != Vector3.zero;
        
        transform.position += moveDir * 8f * Time.deltaTime;
    }

    /// <summary>
    /// Snap the position of the playable to a given vector.
    /// </summary>
    /// <param name="v"></param>
    public void SnapPosition(Vector3Variable v)
    {
        transform.position = playablePosition.Vec3 = v.Vec3;
        canMove.b = false;
    }

    //metode som gjør at playable stopper når den treffer der den skal
    //når transform.position == playablePosition.Vec3 + MoveVector.V.Vec3 når man trykker A/D
    //når skal den sjekke?

    public void ResetPosition()
    {
        transform.position = playablePosition.Vec3 = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point")) 
        { sphereCollision?.Invoke(); }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hinder")) 
        {
            addedScoreForCollision.DecrementToMinOne();
        }
    }
}