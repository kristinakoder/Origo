using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Variable", menuName = "Scriptable Objects/Vector3Variable")]
public class Vector3Variable : ScriptableObject //ScriptableObject er på en måte en mal til et component
{
    public Vector3 Vec3 { get; set; }
}