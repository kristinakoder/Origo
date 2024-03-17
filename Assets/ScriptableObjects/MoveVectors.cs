using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveVectors", menuName = "Scriptable Objects/MoveVectors")]
public class MoveVectors : ScriptableObject //ScriptableObject er på en måte en mal til et component
{
    public Vector3Variable V { get; set; }
    public Vector3Variable W { get; set; }
}