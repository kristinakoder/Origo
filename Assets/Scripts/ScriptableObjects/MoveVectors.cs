using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveVectors", menuName = "Scriptable Objects/MoveVectors")]
public class MoveVectors : ScriptableObject
{
    public Vector3Variable V;
    public Vector3Variable W;
    public Vector3Variable U;

    public void ResetVectors()
    { V.Vec3 = W.Vec3 = U.Vec3 = Vector3.zero; }   
}