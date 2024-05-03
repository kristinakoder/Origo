using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HintController : MonoBehaviour
{
    public AllTasks allTasks;

    TextMeshProUGUI textMeshPro;
    TaskSO activeTask;
    bool isHintShown = false;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GetActiveTask();
            isHintShown = !isHintShown;
            if (!isHintShown)
                RemoveHint();
            else
                ShowHints();
        }
    }

    public void ShowHints()
    {
        textMeshPro.text = activeTask.hint;        
    }

    void GetActiveTask()
    {
        foreach (TaskSO task in allTasks.tasks)
            if (task.IsActive)
                activeTask = task;
    }

    public void RemoveHint()
    {
        textMeshPro.text = "";
    }
}