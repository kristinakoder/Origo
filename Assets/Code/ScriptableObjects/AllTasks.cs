using System.Collections;
using System.Collections.Generic;
using UnityEditor.Analytics;
using UnityEngine;

[CreateAssetMenu(fileName = "New AllTask", menuName = "Scriptable Objects/AllTask")]
public class AllTasks : ScriptableObject
{
    public List<TaskSO> tasks = new List<TaskSO>();
    public IntVariable score;
    public IntVariable scoreThreshold;

    public void Reset()
    {
        foreach (TaskSO task in tasks)
        {
            task.Reset();
        }
        tasks[0].SetActive();
    }

    public void CompleteAndSetNextActive()
    {
        for(int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].IsActive)
            {
                tasks[i].Complete();
                if (i < tasks.Count - 1)         
                    tasks[i + 1].SetActive();
                break;
            }
        }
    }
}