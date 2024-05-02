using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Variable", menuName = "Scriptable Objects/Vector3Variable")]
public class Vector3Variable : ScriptableObject
{
    [SerializeField] private Vector3 _vec3;
    public Vector3 Vec3
    {
        get => _vec3;
        set => _vec3 = value;
    } 
        
    /// <summary>
    /// Set value for movement in the x-axis.
    /// </summary>
    /// <param name="s"></param>
    public void SetValueX(string s) => _ = int.TryParse(s, out int a) ? _vec3.x = a : 0;
    
    /// <summary>
    /// Set value for movement in the y-axis. (Binds to z since we use that for depth)
    /// </summary>
    /// <param name="s"></param>
    public void SetValueY(string s) => _ = int.TryParse(s, out int a) ? _vec3.z = a : 0;
    
    /// <summary>
    /// Set value for movement in the z-axis. (Binds to y since we use that for depth)
    /// </summary>
    /// <param name="s"></param>
    public void SetValueZ(string s) => _ = int.TryParse(s, out int a) ? _vec3.y = a : 0;

    /// <summary>
    ///  Set a new vector with a given vector.
    /// </summary>
    /// <param name="v"></param>
    public void SetVector(Vector3 v) => _vec3 = v;

    /// <summary>
    /// Get normalized vector.
    /// </summary>
    public Vector3 GetNormalized()
    {
        Vector3 normalized = _vec3;
        normalized.Normalize();
        return normalized;
    }

}