using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMoveVectors : MonoBehaviour
{
    public MoveVectors moveVectors;
    Vector3 v, w;
    LineRenderer lineV, lineW;

    void Start()
    {
        v = moveVectors.V.Vec3;
        w = moveVectors.W.Vec3;
        v.Normalize();
        w.Normalize();
        lineV = lineW = GetComponent<LineRenderer>();       
    }

    
    //trenger en metode for å tegne de (som må kjøres når playableObject beveger seg)
    //trenger å vite når de må endre seg
}
