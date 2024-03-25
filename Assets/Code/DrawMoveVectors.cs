using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMoveVectors : MonoBehaviour
{
    public MoveVectors moveVectors;
    public LineRenderer rendererV; 
    public LineRenderer rendererW;
    Vector3 v, w;


    void Start()
    {
        v = moveVectors.V.Vec3.normalized;
        w = moveVectors.W.Vec3.normalized;

        Vector3 startPoint = new (transform.position.x, 0.05f, transform.position.z);
        rendererV.SetPositions(new Vector3[] { startPoint, new (v.x, 0.05f, v.z) });
        rendererW.SetPositions(new Vector3[] { startPoint, new (w.x, 0.05f, w.z) });      
    }
}
