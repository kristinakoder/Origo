using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Task", menuName = "Scriptable Objects/Task")]
public class TaskSO : ScriptableObject 
{
    public string Description;
    public bool IsCompleted;
    public bool IsActive;
    public int pointsRewarded;

    public void Complete()
    {
        IsActive = false;
        IsCompleted = true;
    }

    public void SetActive()
    {
        IsActive = true;
    }

    public void Reset()
    {
        IsActive = false;
        IsCompleted = false;
    }   
}