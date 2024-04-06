using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IntVariable", menuName = "Scriptable Objects/IntVariable")]
public class IntVariable : ScriptableObject
{  
    public int i;      

    public void Increment()
    {
        i++;
    }

    public void Reset()
    {
        i = 0;
    }
}