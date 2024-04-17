using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Variable", menuName = "Scriptable Objects/Vector3Variable")]
public class Vector3Variable : ScriptableObject
{
    public Vector3 Vec3;

    /// <summary>
    /// Set value for movement in the x-axis.
    /// </summary>
    /// <param name="s"></param>
    public void SetValueX(String s)
    { _ = int.TryParse(s, out int a) ? Vec3.x = a : 0; }
    
    /// <summary>
    /// Set value for movement in the y-axis. (Binds to z since we use that for depth)
    /// </summary>
    /// <param name="s"></param>
    public void SetValueY(String s)
    { _ = int.TryParse(s, out int a) ? Vec3.z = a : 0; }
    
    /// <summary>
    /// Set value for movement in the z-axis. (Binds to y since we use that for depth)
    /// </summary>
    /// <param name="s"></param>
    public void SetValueZ(String s)
    { _ = int.TryParse(s, out int a) ? Vec3.y = a : 0; }
}