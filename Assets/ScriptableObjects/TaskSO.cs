using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Scriptable Objects/Task")]
public class TaskSO : ScriptableObject //
{
    public string Description;
    public bool IsCompleted;
    public bool IsActive;

    public void Complete()
    {
        IsActive = false;
        IsCompleted = true;
    }
}