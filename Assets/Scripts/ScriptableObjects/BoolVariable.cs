using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BoolVariable", menuName = "Scriptable Objects/BoolVariable")]
public class BoolVariable : ScriptableObject
{
    public bool b;

    public void Toggle() => b = !b;

    public void SetTrue() => b = true;

    public void SetFalse() => b = false;

    public void Set(bool value) => b = value;
}