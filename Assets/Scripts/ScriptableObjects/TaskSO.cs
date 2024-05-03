using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Task", menuName = "Scriptable Objects/Task")]
public class TaskSO : ScriptableObject 
{
    public string description;
    public string hint;
    public bool IsActive,is3D,useV,useW,useU,useHinder,usePoint,lockVectors;

    public void SetActive() => IsActive = true;

    public void Reset() => IsActive = false;
}