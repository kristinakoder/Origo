using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AllTask", menuName = "Scriptable Objects/AllTask")]
public class AllTasks : ScriptableObject
{
    public TaskSO zero;
    public TaskSO one;
    public TaskSO two;
    public TaskSO three;
}