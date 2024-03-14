using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Task", menuName = "ScriptableObjects/Task")]
public class Task : ScriptableObject
{
    public string description;
    public bool isActive;
}
