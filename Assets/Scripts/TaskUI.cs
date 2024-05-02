using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    public GameObject textPrefab;
    public AllTasks allTasks;
    GameObject newText;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        newText = Instantiate(textPrefab, transform); 
        newText.transform.localPosition = new Vector3(-300, -100, 0f); 
        textMeshPro = newText.GetComponent<TextMeshProUGUI>();  
        ShowActiveTask();
    }

    public void ShowActiveTask()
    {
        foreach (TaskSO task in allTasks.tasks)
            if (task.IsActive)
                textMeshPro.text = task.Description;
    }
}