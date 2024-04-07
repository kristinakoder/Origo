using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;

public class VectorInput : MonoBehaviour
{
    public MoveVectors moveVectors;
    public GameEvent onTaskComplete;
    bool addedVX = false, addedVY = false;

    void Start()
    {
        moveVectors.V.Vec3 = moveVectors.W.Vec3 = Vector3.zero;
    }

    public void GetVX(string input) 
    { 
        if (int.TryParse(input, out int a)) 
        {
            moveVectors.V.Vec3.x = a;
            if (!addedVX) 
            {
                addedVX = true;
                VectorVAdded();
            }
        }
    }

    public void GetVY(string input) 
    { 
        if (int.TryParse(input, out int a)) 
        {
            moveVectors.V.Vec3.z = a;
            if (!addedVY) 
            {
                addedVY = true;
                VectorVAdded();
            }
        }
    }

    public void GetWX(string input)
    { _ = int.TryParse(input, out int a) ? moveVectors.W.Vec3.x = a : 0; }

    public void GetWY(string input)
    { _ = int.TryParse(input, out int a) ? moveVectors.W.Vec3.z = a : 0; }

    public void VectorVAdded()
    {
        if (addedVX && addedVY)
            onTaskComplete.Raise();
    }

    public void ResetVectors()
    {
        moveVectors.V.Vec3 = moveVectors.W.Vec3 = moveVectors.U.Vec3 = Vector3.zero;
    }
}