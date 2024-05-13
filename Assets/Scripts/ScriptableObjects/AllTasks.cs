using System.Collections;
using System.Collections.Generic;
using UnityEditor.Analytics;
using UnityEngine;

[CreateAssetMenu(fileName = "New AllTask", menuName = "Scriptable Objects/AllTask")]
public class AllTasks : ScriptableObject
{
    public List<TaskSO> tasks = new List<TaskSO>();

    public void Reset()
    {
        foreach (TaskSO task in tasks)
        { task.Reset(); }
        tasks[0].SetActive();
    }

    public void ChooseRandomTask()
    {
        Reset();
        int randomIndex = Random.Range(0, tasks.Count);
        tasks[randomIndex].SetActive();
    }
}