using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Task", menuName = "Scriptable Objects/Task")]
public class TaskSO : ScriptableObject //
{
    public string Description;
    public bool IsCompleted;
    public bool IsActive;
    public int pointsRewarded;
    //public UnityEvent SetActiveEvent; Nei, for da må hver referanse legges inn på hver GameEvent.asset..... Gah.. TaskManager?!

    public void Complete()
    {
        IsActive = false;
        IsCompleted = true;
    }

    public void SetActive()
    {
        IsActive = true;
        //SetActiveEvent?.Invoke();
    }
}