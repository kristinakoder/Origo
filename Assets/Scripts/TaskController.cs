using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    [SerializeField] private IntVariable collisionCount;
    [SerializeField] private AllTasks allTasks;

    void Start()
    {
        collisionCount.Reset();
        allTasks.Reset();
    }

    public void NextTask()
    {
        if (collisionCount.i == 0)
        {
            allTasks.CompleteAndSetNextActive();
            collisionCount.Reset();
        }
    }
}