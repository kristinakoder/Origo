using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DrawMoveVectors : MonoBehaviour
{
    [SerializeField] private MoveVectors moveVectors;
    [SerializeField] private LineRenderer rendererV, rendererW, rendererU;
    [SerializeField] private BoolVariable isMoving;
    Vector3 v, w, u;

    void Update()
    {
        if (isMoving.b)
            DrawVectors();
    }

    public void DrawVectors()
    {
        v = moveVectors.V.GetNormalized();
        w = moveVectors.W.GetNormalized();
        u = moveVectors.U.GetNormalized();

        rendererV.SetPositions(new Vector3[] { transform.position, transform.position + new Vector3(v.x, v.y, v.z) });
        rendererW.SetPositions(new Vector3[] { transform.position, transform.position + new Vector3(w.x, w.y, w.z) });
        rendererU.SetPositions(new Vector3[] { transform.position, transform.position + new Vector3(u.x, u.y, u.z) });
    }
}